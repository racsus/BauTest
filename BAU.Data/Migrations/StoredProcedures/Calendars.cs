using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU.Data.Migrations.StoredProcedures
{
    public class Calendars
    {
        public const String sp_CalendarsPaginationDrop = @"IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_CalendarsGetPaginatedByFilter')
                                                BEGIN
                                                    DROP PROCEDURE SP_CalendarsGetPaginatedByFilter
                                                END";
        public const String sp_CalendarsPaginationCreate = @"CREATE PROC [SP_CalendarsGetPaginatedByFilter]
                                                @PAGENUMBER INT,
                                                @PAGESIZE INT,
                                                @ORDERBY VARCHAR(50),
                                                @DIRECCION VARCHAR(4),
                                                @WHERE_CLAUSE VARCHAR(MAX)
                                                AS
                                                DECLARE @SPAGENUMBER VARCHAR(MAX)= Convert(varchar, @PAGENUMBER)
                                                DECLARE @SPAGESIZE VARCHAR(MAX)= Convert(varchar, @PAGESIZE)
                                                IF LTRIM(@WHERE_CLAUSE) = ''
                                                BEGIN
	                                                SET @WHERE_CLAUSE = ' (1 = 1) '
                                                END
                                                EXEC (' SELECT Id, Date, IdEngineer, Shift FROM Calendars WITH(NOLOCK)
                                                 WHERE ' + @WHERE_CLAUSE + '  
	                                                 ORDER BY ' + @ORDERBY + ' ' + @DIRECCION + ' OFFSET (' + @SPAGESIZE + ' * (' + @SPAGENUMBER + ' - 1)) ROWS FETCH NEXT ' + @SPAGESIZE + ' ROWS ONLY ')";

        public const String sp_CalendarsPaginationCountDrop = @"IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_CalendarsGetCountByFilter')
                                                BEGIN
                                                    DROP PROCEDURE SP_CalendarsGetCountByFilter
                                                END";
        public const String sp_CalendarsPaginationCountCreate = @"CREATE PROC SP_CalendarsGetCountByFilter
                                                @WHERE_CLAUSE VARCHAR(MAX)
                                                AS

                                                IF LTRIM(@WHERE_CLAUSE) = ''
                                                BEGIN
	                                                SET @WHERE_CLAUSE = ' (1 = 1) '
                                                END
                                                EXEC (' SELECT Count(1) FROM Calendars WITH(NOLOCK)
                                                 WHERE ' + @WHERE_CLAUSE + ' 
	                                                ')";
    }
}
