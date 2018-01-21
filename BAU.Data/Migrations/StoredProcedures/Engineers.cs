using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU.Data.Migrations.StoredProcedures
{
    public class Engineers
    {
        public const String sp_EngineersPaginationDrop = @"IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_EngineersGetPaginatedByFilter')
                                                BEGIN
                                                    DROP PROCEDURE SP_EngineersGetPaginatedByFilter
                                                END";
        public const String sp_EngineersPaginationCreate = @"CREATE PROC [SP_EngineersGetPaginatedByFilter]
                                                @PAGENUMBER INT,
                                                @PAGESIZE INT,
                                                @ORDERBY VARCHAR(50),
                                                @DIRECCION VARCHAR(4),
                                                @WHERE_CLAUSE VARCHAR(MAX)
                                                AS
                                                BEGIN
                                                SET NOCOUNT ON;
                                                DECLARE @SPAGENUMBER VARCHAR(MAX)= Convert(varchar, @PAGENUMBER)
                                                DECLARE @SPAGESIZE VARCHAR(MAX)= Convert(varchar, @PAGESIZE)
                                                IF LTRIM(@WHERE_CLAUSE) = ''
                                                BEGIN
                                                 SET @WHERE_CLAUSE = ' (1 = 1) '
                                                END
                                                EXEC (' SELECT Id, Name FROM Engineers 
                                                 WHERE ' + @WHERE_CLAUSE + '  
                                                  ORDER BY ' + @ORDERBY + ' ' + @DIRECCION + ' OFFSET (' + @SPAGESIZE + ' * (' + @SPAGENUMBER + ' - 1)) ROWS FETCH NEXT ' + @SPAGESIZE + ' ROWS ONLY ')
                                                END";

        public const String sp_EngineersPaginationCountDrop = @"IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_EngineersGetCountByFilter')
                                                BEGIN
                                                    DROP PROCEDURE SP_EngineersGetCountByFilter
                                                END";
        public const String sp_EngineersPaginationCountCreate = @"CREATE PROC SP_EngineersGetCountByFilter
                                                @WHERE_CLAUSE VARCHAR(MAX)
                                                AS

                                                IF LTRIM(@WHERE_CLAUSE) = ''
                                                BEGIN
	                                                SET @WHERE_CLAUSE = ' (1 = 1) '
                                                END
                                                EXEC (' SELECT Count(1) FROM Engineers WITH(NOLOCK)
                                                 WHERE ' + @WHERE_CLAUSE + ' 
	                                                ')";
    }
}
