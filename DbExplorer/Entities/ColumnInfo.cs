using System;
using System.Collections.Generic;
using System.Linq;

namespace DbExplorer.Entities
{
    /// <summary>
    /// Represents an individual column's information in a given table.
    /// </summary>
    public class ColumnInfo
    {
        public const string Query = "SELECT  ORDINAL_POSITION AS 'OrdinalPosition', C.TABLE_NAME AS 'TableName', C.COLUMN_NAME AS 'ColumnName', DATA_TYPE AS 'DataType', CHARACTER_MAXIMUM_LENGTH AS 'MaxCharacterLength', IS_NULLABLE AS 'IsNullable', COLUMN_DEFAULT AS 'DefaultValue', S.value AS 'Description', COUNT(CCU.COLUMN_NAME) AS 'CountOfCheckContraints' FROM    INFORMATION_SCHEMA.COLUMNS C LEFT OUTER JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE CCU ON C.COLUMN_NAME = CCU.COLUMN_NAME AND C.TABLE_NAME = CCU.TABLE_NAME LEFT OUTER JOIN sys.extended_properties S  ON  S.major_id = OBJECT_ID(C.TABLE_SCHEMA + '.' + C.TABLE_NAME) AND S.minor_id = C.ORDINAL_POSITION AND S.class = 1 AND S.name = 'MS_Description' WHERE    C.TABLE_NAME = @TableName GROUP BY ORDINAL_POSITION, C.TABLE_NAME, C.COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE, COLUMN_DEFAULT, S.value ORDER BY  ORDINAL_POSITION ASC;";
        public const string QueryParameterName = "@TableName";

        /// <summary>'ORDINAL_POSITION'</summary>
        public int OrdinalPosition { get; set; }
        /// <summary>'Table_NAME'</summary>
        public string TableName { get; set; }
        /// <summary>'COLUMN_NAME'</summary>
        public string ColumnName { get; set; }
        /// <summary>'DATA_TYPE'</summary>
        public string DataType { get; set; }
        /// <summary>'CHARACTER_MAXIMUM_LENGTH'</summary>
        public int? MaxCharacterLength { get; set; }
        /// <summary>'IS_NULLABLE'</summary>
        public bool IsNullable { get; set; }
        /// <summary>'COLUMN_DEFAULT'</summary>
        public string DefaultValue { get; set; }
        /// <summary>'Description'</summary>
        public string Description { get; set; }
        /// <summary>'CountOfCheckContraints'</summary>
        public int CountOfCheckContraints { get; set; }
    }
}
