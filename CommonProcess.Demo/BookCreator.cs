using System;
using CommonProcess.Demo.Core;
using CommonProcess.DependentProvider;

namespace CommonProcess.Demo
{
    internal class BookCreator : OperateProcess
    {
        private readonly string _name;

        public BookCreator(DataProcessConfig config, string name)
            : base(config)
        {
            this._name = name;
        }

        protected override bool PreCheckProcessDataLegal()
        {
            if (string.IsNullOrEmpty(this._name))
            {
                base.CacheArgumentIsNullError("Name");
                return false;
            }

            return true;
        }

        protected override bool ProcessMainData()
        {
            var bookRepository = base.ResolveDependency<IBookRepository>();

            if (!bookRepository.Create(new Book(Guid.NewGuid().ToString(), this._name)))
            {
                base.CacheError(-100, "create book error");
                return false;
            }

            return true;
        }

        protected override bool ProcessRelationData()
        {
            return true;
        }
    }

    internal class BookCreatorDependentProvider : BaseDependentProvider
    {
        protected override void RegistDefault()
        {
            base.RegisterDependent<IBookRepository>(new BookRepository());
        }
    }
}
