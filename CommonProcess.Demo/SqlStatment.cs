using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonProcess.Demo
{
    public class SqlStatment
    {
        public List<string> Column { get; set; }

        public string Table { get; set; }

        public List<SqlWhereCondition> WhereConditions { get; set; }

        public SqlSkipTakeCondition SkipTakeCondition { get; set; }

        public string OrderBy { get; set; }

        public override string ToString()
        {
            return ToSql();
        }

        public string ToSql()
        {
            var sb = new StringBuilder();
            sb.Append("SELECT");
            sb.AppendSpace();

            sb.Append(GenerateColumnString());
            sb.AppendSpace();

            sb.Append("FROM");
            sb.AppendSpace();

            sb.Append(TableNameMapping(this.Table));

            GenerateWhereCondition(ref sb);

            return sb.ToString();
        }

        private string GenerateColumnString()
        {
            var columnString = new StringBuilder();

            foreach (var column in this.Column)
            {
                columnString.Append(column);
                columnString.Append(",");
            }

            columnString.Remove(columnString.Length - 1, 1);

            return columnString.ToString();
        }

        private void GenerateWhereCondition(ref StringBuilder sb)
        {
            if (this.WhereConditions == null || !this.WhereConditions.Any()) return;

            sb.AppendSpace();
            sb.Append("WHERE");

            for (int i = 0; i < this.WhereConditions.Count; i++)
            {
                sb.AppendSpace();
                var condistion = this.WhereConditions[i];
                switch (condistion.ConditionType)
                {
                    case SqlWhereConditionType.Equal:
                        if (condistion.Condition is string)
                        {
                            sb.Append(string.Format("[{0}] = '{1}'", condistion.Column, condistion.Condition));
                        }
                        else if (condistion.Condition is int || condistion.Condition is long)
                        {
                            sb.Append(string.Format("[{0}] = {1}", condistion.Column, condistion.Condition));
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }
                        break;
                    case SqlWhereConditionType.Great:
                        break;
                    case SqlWhereConditionType.In:
                        break;
                    case SqlWhereConditionType.IsNull:
                        break;
                    default:
                        throw new NotImplementedException();
                }
                if (i != this.WhereConditions.Count - 1)
                {
                    sb.AppendSpace();
                    sb.Append("AND");
                }
            }
        }

        private string TableNameMapping(string tableName)
        {
            return tableName;
        }
    }

    public enum SqlWhereConditionType
    {
        Equal = 1,
        Great = 2,
        In = 4,
        IsNull = 5
    }

    public class SqlWhereCondition
    {
        public string Column { get; set; }

        public SqlWhereConditionType ConditionType { get; set; }

        public object Condition { get; set; }
    }

    public class SqlSkipTakeCondition
    {
        public int Skip { get; set; }

        public int Take { get; set; }
    }
}
