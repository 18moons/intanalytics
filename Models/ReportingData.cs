using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MibClient2.Database;
using System.Data;

namespace DXAnalytics.Models
{
    public class ReportingData
    {
        #region ControlPanel
        /// <summary>
        /// Retorno um data set de visitas para o controle de painel
        /// </summary>
        /// <returns></returns>
        public static DataSet ControlPanelVisits()
        {
            var currentFilters = ReportFilters.GetFromCookie();
            var strSQL = @"
            SELECT
	            COUNT(*) TOTAL,
	            [DATE]
            FROM
            (
	            SELECT DISTINCT
		            DXAS.ID,
		            CONVERT(VARCHAR(10),DXAS.SESSION_START,111) AS [DATE],
		            DXP.USERID
	            FROM
		            DX_ANALYTICS_SESSIONS (NOLOCK) DXAS
	            LEFT JOIN
		            DX_PROFILES DXP (NOLOCK)
	            ON
		            DXAS.PROFILE_ID = DXP.ID
	            LEFT JOIN
		            DX_KEYS DXK (NOLOCK)
	            ON
		            DXK.USERID = DXP.USERID
	            WHERE
		            DXAS.SESSION_START BETWEEN ? AND ?";
            if(currentFilters.PlanId!=0)
            strSQL+=@"
		            AND DXK.SUBSCRIPTION_PLAN = ?";
            strSQL+=@"
            ) SUB
            GROUP BY
	            [DATE]
            ORDER BY [DATE]";
            var sqlBuilder = new MibSqlBuilder(strSQL);
            sqlBuilder.AddParameter(currentFilters.StartDate);
            sqlBuilder.AddParameter(currentFilters.EndDate);
            if(currentFilters.PlanId!=0)
                sqlBuilder.AddParameter(currentFilters.PlanId);
            return MibSql.Default.CreateQuery(sqlBuilder).GetDataSet();
        }

        /// <summary>
        /// Retorno um data set para de estatísticas das visitas para o controle de painel
        /// </summary>
        /// <returns></returns>
        public static DataSet ControlPanelStatistics()
        {
            /*var strSQL = String.Empty;
            var currentFilters = ReportFilters.GetFromCookie();
            MibSqlBuilder sqlBuilder;
            var DS = new DataSet();
            strSQL += @" EXEC SP_DXA_TOTAL_VISITS ?, ?, ?";
            strSQL += @" EXEC SP_DXA_TOTAL_TRAILERS_DISPLAYES ?, ?, ?";
            strSQL += @" EXEC SP_DXA_TOTAL_TRAILERS_CONTENT ?, ?, ?";
            strSQL += @" EXEC SP_DXA_TOTAL_TIME_APP ?, ?, ?";
            strSQL += @" EXEC SP_DXA_TIME_MOVIE ?, ?, ?";
            strSQL += @" EXEC SP_DXA_TAX_ABANDON ?, ?, ?";
            sqlBuilder = new MibSqlBuilder(strSQL);
            if(DateTime.Compare(currentFilters.StartDate.Date, DateTime.Now.AddDays(-30).Date) < 0)
            {
                currentFilters.PlanId = 0;
                currentFilters.StartDate = DateTime.Now.AddDays(-30);
                currentFilters.EndDate = DateTime.Now.AddDays(1);
            }
            sqlBuilder.AddParameter(currentFilters.PlanId);
            sqlBuilder.AddParameter(currentFilters.StartDate);
            sqlBuilder.AddParameter(currentFilters.EndDate);
            sqlBuilder.AddParameter(currentFilters.PlanId);
            sqlBuilder.AddParameter(currentFilters.StartDate);
            sqlBuilder.AddParameter(currentFilters.EndDate);
            sqlBuilder.AddParameter(currentFilters.PlanId);
            sqlBuilder.AddParameter(currentFilters.StartDate);
            sqlBuilder.AddParameter(currentFilters.EndDate);
            sqlBuilder.AddParameter(currentFilters.PlanId);
            sqlBuilder.AddParameter(currentFilters.StartDate);
            sqlBuilder.AddParameter(currentFilters.EndDate);
            sqlBuilder.AddParameter(currentFilters.PlanId);
            sqlBuilder.AddParameter(currentFilters.StartDate);
            sqlBuilder.AddParameter(currentFilters.EndDate);
            sqlBuilder.AddParameter(currentFilters.PlanId);
            sqlBuilder.AddParameter(currentFilters.StartDate);
            sqlBuilder.AddParameter(currentFilters.EndDate);
            return MibSql.Default.CreateQuery(sqlBuilder).GetDataSet();*/
            return null;
        }
        #endregion ControlPanel

        #region Preferences
        /// <summary>
        /// Retorno de um dataset com as preferencias de acordo com o tipo requerido
        /// </summary>
        /// <returns></returns>
        public static DataSet Preferences(EReportingPreferences preferences)
        {
            var cookie = ReportFilters.GetFromCookie();
            var strSQL = @" EXEC SP_DXA_PREFERENCES ?, ?";
            var sqlBuilder = new MibSqlBuilder(strSQL);
            sqlBuilder.AddParameter(preferences);
            sqlBuilder.AddParameter(cookie.PlanId);
            return MibSql.Default.CreateQuery(sqlBuilder).GetDataSet();
        }
        #endregion Preferences

        public static DataSet UsersSubscriptions()
        {
            ReportFilters currentFilters = ReportFilters.GetFromCookie();
            string sql = @"
            SELECT
	            COUNT(*) TOTAL,
	            DATE
            FROM
            (
	            SELECT DISTINCT
		            USR.ID,
		            CONVERT(VARCHAR(10),USR.DATEINS,111) DATE
	            FROM
		            DX_USERS (NOLOCK) USR
	            LEFT JOIN
		            DX_KEYS (NOLOCK) KS
	            ON
		            KS.USERID=USR.ID
	            WHERE
		            USR.DATEINS BETWEEN ? and ?";
            if (currentFilters.PlanId != 0)
            {
                sql += @"
	                AND KS.SUBSCRIPTION_PLAN=?";
            }
            sql += @"
            ) SUB1
            GROUP BY
	            DATE";
            MibSqlBuilder sqlBuilder = new MibSqlBuilder(sql);
            sqlBuilder.AddParameter(currentFilters.StartDate);
            sqlBuilder.AddParameter(currentFilters.EndDate);
            if (currentFilters.PlanId != 0)
            {
                sqlBuilder.AddParameter(currentFilters.PlanId);
            }
            return MibSql.Default.CreateQuery(sqlBuilder).GetDataSet();
        }

        public static DataSet UserAudience()
        {
            ReportFilters currentFilters = ReportFilters.GetFromCookie();
            string sql = @"
                SELECT
	                COUNT(*) TOTAL,
	                AUDIENCE_HOUR,
	                SH
                FROM
                (
	                SELECT DISTINCT
		                CAST(DATEPART(HOUR, S.SESSION_START) AS VARCHAR(2)) + ':00' AS AUDIENCE_HOUR,
		                S.SESSION_START,
		                DATEPART(HOUR, S.SESSION_START) SH,
		                S.ID
	                FROM
		                DX_ANALYTICS_SESSIONS (NOLOCK) AS S  
	                LEFT JOIN
		                DX_PROFILES (NOLOCK) as p
	                on
		                S.PROFILE_ID = P.ID
	                LEFT JOIN
		                DX_KEYS (NOLOCK) AS K
	                ON
		                P.USERID = K.USERID
	                WHERE 
		                (S.SESSION_START BETWEEN ? AND ?)";

            if (currentFilters.PlanId != 0)
                sql += @" AND K.SUBSCRIPTION_PLAN = ?";

            sql += @"
                ) SUB1
                GROUP BY
	                AUDIENCE_HOUR,
	                SH
                ORDER BY
	                SH";

            MibSqlBuilder sqlBuilder = new MibSqlBuilder(sql);
            sqlBuilder.AddParameter(currentFilters.StartDate);
            sqlBuilder.AddParameter(currentFilters.EndDate);
            if (currentFilters.PlanId != 0)
                sqlBuilder.AddParameter(currentFilters.PlanId);


            return MibSql.Default.CreateQuery(sqlBuilder).GetDataSet();
        }

        public static DataSet SessionTimming()
        {
            ReportFilters currentFilters = ReportFilters.GetFromCookie();
            string sql = @"
            SELECT
	            COUNT(*) TOTAL,
	            NAME
            FROM
            (
	            SELECT DISTINCT
		            R.RANGE_NAME AS NAME, 
		            S.ID,
		            S.SESSION_START,
		            P.USERID
	            FROM
		            DX_ANALYTICS_SESSIONS	(NOLOCK) AS S 
	            LEFT JOIN
		            DX_PROFILES	(NOLOCK) AS P
	            ON 
		            P.ID    = S.PROFILE_ID
	            LEFT JOIN
		            DX_KEYS		(NOLOCK) AS K
	            ON
		            K.USERID = P.USERID
	            LEFT JOIN
		            DX_ANALYTICS_SESSION_FILTER		(NOLOCK) AS R
	            ON
		            DATEDIFF(MINUTE, SESSION_START, ISNULL(SESSION_END,SESSION_START)) >= R.MINIMUM_VALUE
		            AND DATEDIFF(MINUTE, SESSION_START, ISNULL(SESSION_END,SESSION_START)) <  R.MAXIMUM_VALUE
	            WHERE
		            (S.SESSION_START BETWEEN ? AND ?)"; 
                if (currentFilters.PlanId != 0)
                    sql += @"AND K.SUBSCRIPTION_PLAN = ?";
                sql += @"
                ) SUB1
                            GROUP BY
	                            NAME
                            ORDER BY
	                            TOTAL DESC";
            MibSqlBuilder sqlBuilder = new MibSqlBuilder(sql);
            sqlBuilder.AddParameter(currentFilters.StartDate);
            sqlBuilder.AddParameter(currentFilters.EndDate);
            if (currentFilters.PlanId != 0)
                sqlBuilder.AddParameter(currentFilters.PlanId);

            return MibSql.Default.CreateQuery(sqlBuilder).GetDataSet();
        }

        public static DataSet ProfilesPerUser()
        {
            ReportFilters currentFilters = ReportFilters.GetFromCookie();
            string sql = @"
            SELECT
	            COUNT(NAME) TOTAL,
	            TOTAL PROFILES
            FROM
	            DX_USERS_PROFILECOUNT (NOLOCK) 
            WHERE
	            DATEINS BETWEEN ? AND ?";
            if (currentFilters.PlanId != 0)
            {
                sql += @"
	            AND SUBSCRIPTION_PLAN=?";
            }
            sql += @"
            GROUP BY    
	            TOTAL";
            MibSqlBuilder sqlBuilder = new MibSqlBuilder(sql);
            sqlBuilder.AddParameter(currentFilters.StartDate);
            sqlBuilder.AddParameter(currentFilters.EndDate);
            if (currentFilters.PlanId != 0)
            {
                sqlBuilder.AddParameter(currentFilters.PlanId);
            }
            return MibSql.Default.CreateQuery(sqlBuilder).GetDataSet();
        }

        public static DataSet ActivatedKeys()
        {
            ReportFilters currentFilters = ReportFilters.GetFromCookie();
            string sql = @"
            SELECT
	            (SELECT COUNT(ID) FROM DX_KEYS (NOLOCK) WHERE ACTIVE=1";

            if (currentFilters.PlanId != 0)
            {
                sql += " AND SUBSCRIPTION_PLAN=?";
            }
            sql += ") ACTIVATED,";
            sql += @"
	            (SELECT COUNT(ID) FROM DX_KEYS (NOLOCK) ";
            if (currentFilters.PlanId != 0)
            {
                sql += @" WHERE SUBSCRIPTION_PLAN=?";
            }
            sql += ") TOTAL";
            MibSqlBuilder sqlBuilder = new MibSqlBuilder(sql);
            if (currentFilters.PlanId != 0)
            {
                sqlBuilder.AddParameter(currentFilters.PlanId);
                sqlBuilder.AddParameter(currentFilters.PlanId);
            }
            return MibSql.Default.CreateQuery(sqlBuilder).GetDataSet();
        }

        public static DataSet LastLogin()
        {
            ReportFilters currentFilters = ReportFilters.GetFromCookie();
            string sql = @"
                            SELECT TOP 30
	                            DATEDIFF(DAY,LAST_LOGIN,GETDATE()) [DAYS],
	                            COUNT(*) TOTAL
                            FROM
	                            (
		                            SELECT
			                            MAX(S.SESSION_END) LAST_LOGIN,
			                            S.PROFILE_ID
		                            FROM
			                            DX_ANALYTICS_SESSIONS S
		                            INNER JOIN	
			                            DX_PROFILES P
		                            ON
			                            P.ID=S.PROFILE_ID
		                            INNER JOIN
			                            DX_KEYS K
		                            ON
			                            K.USERID=P.USERID
		                            WHERE
			                            S.SESSION_END BETWEEN ? AND ?";
            if (currentFilters.PlanId != 0)
                sql+=@"
			                            AND K.SUBSCRIPTION_PLAN=?";
            sql+=@"
		                            GROUP BY
			                            S.PROFILE_ID
	                            ) T1
                            WHERE
	                            LAST_LOGIN IS NOT NULL
                            GROUP BY
	                            DATEDIFF(DAY,LAST_LOGIN,GETDATE())
                            ORDER BY
	                            DAYS";
            MibSqlBuilder sqlBuilder = new MibSqlBuilder(sql);
            sqlBuilder.AddParameter(currentFilters.StartDate);
            sqlBuilder.AddParameter(currentFilters.EndDate);
            if (currentFilters.PlanId != 0)
                sqlBuilder.AddParameter(currentFilters.PlanId);


            return MibSql.Default.CreateQuery(sqlBuilder).GetDataSet();

        }

        public static DataSet MediaPerformance()
        {
            ReportFilters currentFilters = ReportFilters.GetFromCookie();
            string sql = @"
            SELECT
	            SUM(MOVIE) MOVIES,
	            SUM(TRAILER) TRAILERS,
	            [DATE]
            FROM
            (
            SELECT DISTINCT
                CONVERT(VARCHAR(20), TIME, 111) AS [DATE],
                CASE WHEN ACTION_ID = 27 THEN 0 ELSE 1 END AS MOVIE,
                CASE WHEN ACTION_ID = 26 THEN 0 ELSE 1 END AS TRAILER,
                A.ID
            FROM
	            DX_ANALYTICS (NOLOCK) AS A
            LEFT JOIN
	            DX_ANALYTICS_SESSIONS (NOLOCK) AS S
            ON
	            S.ID = A.SESSION_ID
            LEFT JOIN
	            DX_PROFILES (NOLOCK) AS P
            ON
	            S.PROFILE_ID = P.ID
            LEFT JOIN
	            DX_KEYS (NOLOCK) AS K
            ON
	            P.USERID = K.USERID
            WHERE
	            ACTION_ID IN(27,26)
	            AND (S.SESSION_START BETWEEN ? AND ?)";
            if (currentFilters.PlanId != 0)
                sql += @"
                AND K.SUBSCRIPTION_PLAN = ?";
            sql += @"
            ) SUB
            GROUP BY
	            [DATE]
            ORDER BY
	            [DATE]";
            MibSqlBuilder sqlBuilder = new MibSqlBuilder(sql);
            sqlBuilder.AddParameter(currentFilters.StartDate);
            sqlBuilder.AddParameter(currentFilters.EndDate);
            if (currentFilters.PlanId != 0)
                sqlBuilder.AddParameter(currentFilters.PlanId);


            return MibSql.Default.CreateQuery(sqlBuilder).GetDataSet();
        }

        public static DataSet ProfilesAge()
        {
            ReportFilters currentFilters = ReportFilters.GetFromCookie();
            string Sql = @"
            SELECT
	            COUNT(*) TOTAL,
	            AGE
            FROM
            (
	            SELECT DISTINCT
		            P.ID,
		            P.AGE
	            FROM
		            DX_PROFILES (NOLOCK) P
	            INNER JOIN
		            DX_USERS (NOLOCK) U
	            ON
		            P.USERID=U.ID
	            INNER JOIN
		            DX_KEYS (NOLOCK) K
	            ON
		            K.USERID=U.ID";
            if (currentFilters.PlanId != 0)
            {
                Sql += @"
                WHERE
	                K.SUBSCRIPTION_PLAN=?";
            }
            Sql += @"
            ) SUB
            GROUP BY
	            AGE
            ORDER BY
	            TOTAL DESC";
            MibSqlBuilder SqlBuilder = new MibSqlBuilder(Sql);
            if (currentFilters.PlanId != 0)
            {
                SqlBuilder.AddParameter(currentFilters.PlanId);
            }
            return MibSql.Default.CreateQuery(SqlBuilder).GetDataSet();
        }

        public static DataSet ProfilesGender()
        {
            ReportFilters currentFilters = ReportFilters.GetFromCookie();
            string Sql = @"
            SELECT
	            COUNT(*) TOTAL,
	            GENDER
            FROM
            (
	            SELECT DISTINCT
		            P.ID,
		            P.SEX GENDER
	            FROM
		            DX_PROFILES (NOLOCK) P
	            INNER JOIN
		            DX_USERS (NOLOCK) U
	            ON
		            P.USERID=U.ID
	            INNER JOIN
		            DX_KEYS (NOLOCK) K
	            ON
		            K.USERID=U.ID
	            WHERE
		            P.SEX IS NOT NULL";
            if (currentFilters.PlanId != 0)
            {
                Sql += @"
	                AND K.SUBSCRIPTION_PLAN=?";
            }
            Sql += @"
            ) SUB
            GROUP BY
	            GENDER
            ORDER BY
	            TOTAL DESC";
            MibSqlBuilder SqlBuilder = new MibSqlBuilder(Sql);
            if (currentFilters.PlanId != 0)
            {
                SqlBuilder.AddParameter(currentFilters.PlanId);
            }
            return MibSql.Default.CreateQuery(SqlBuilder).GetDataSet();
        }

        public static DataSet ProfilesActivity()
        {
            ReportFilters currentFilters = ReportFilters.GetFromCookie();
            string Sql = @"
            SELECT
	            COUNT(*) TOTAL,
	            NAME
            FROM
            (
	            SELECT
		            P.ID,
		            AC.NAME
	            FROM
		            DX_PROFILES (NOLOCK) P
	            LEFT JOIN
		            DX_USERS (NOLOCK) U
	            ON
		            P.USERID=U.ID
	            LEFT JOIN
		            DX_KEYS (NOLOCK) K
	            ON
		            K.USERID=U.ID
	            LEFT JOIN
		            DX_ACTIVITIES (NOLOCK) AC
	            ON
		            AC.ID=P.ACTIVITYID
	            WHERE
		            AC.NAME IS NOT NULL";
            if (currentFilters.PlanId != 0)
            {
                Sql += @"
	                AND K.SUBSCRIPTION_PLAN=?";
            }
            Sql += @"
            ) SUB
            GROUP BY
	            NAME
            ORDER BY
	            TOTAL DESC";
            MibSqlBuilder SqlBuilder = new MibSqlBuilder(Sql);
            if (currentFilters.PlanId != 0)
            {
                SqlBuilder.AddParameter(currentFilters.PlanId);
            }
            return MibSql.Default.CreateQuery(SqlBuilder).GetDataSet();
        }

        public static DataSet MediaPerformanceAnalytic()
        {
            ReportFilters currentFilters = ReportFilters.GetFromCookie();
            string sql = @"
            SELECT
	            CONTENTID,
	            NAME,
	            SUM(TRAILLER) AS TRAILLER,
	            SUM(MOVIE) AS MOVIE,
	            SUM(RELATED) AS RELATED
            FROM
            (
	            SELECT DISTINCT
		            C.ID AS CONTENTID, 
		            C.NAME,
		            CASE WHEN A.ACTION_ID = 27 THEN 1 ELSE 0 END AS TRAILLER,
		            CASE WHEN A.ACTION_ID = 26 AND RELATED.ACTION_ID != 26 THEN 1 ELSE 0 END AS MOVIE,
		            CASE WHEN A.ACTION_ID = 26 AND RELATED.ACTION_ID  = 26 THEN 1 ELSE 0 END AS RELATED,
		            A.ID
	            FROM
		            CONTENTS (NOLOCK) AS C
	            LEFT JOIN
		            DX_ANALYTICS (NOLOCK) AS A ON A.CONTENT_ID = C.ID
	            LEFT JOIN
		            DX_ANALYTICS (NOLOCK) AS RELATED ON RELATED.ID = A.RELATED_ID
	            LEFT JOIN
		            DX_ANALYTICS_SESSIONS (NOLOCK) AS S ON S.ID = A.SESSION_ID
	            LEFT JOIN
		            DX_PROFILES (NOLOCK) AS P ON S.PROFILE_ID = P.ID
	            LEFT JOIN
		            DX_KEYS (NOLOCK) AS K ON P.USERID = K.USERID
	            WHERE 
		            A.ACTION_ID IN(27,26)
		            AND (S.SESSION_START BETWEEN ? AND ?)";

            if (currentFilters.PlanId != 0)
                sql += @"
                    AND K.SUBSCRIPTION_PLAN = ?";

            sql += @"
            ) SUB
            GROUP BY
	            CONTENTID,
	            NAME
            ORDER BY
	            TRAILLER DESC";

            MibSqlBuilder sqlBuilder = new MibSqlBuilder(sql);
            sqlBuilder.AddParameter(currentFilters.StartDate);
            sqlBuilder.AddParameter(currentFilters.EndDate);
            if (currentFilters.PlanId != 0)
                sqlBuilder.AddParameter(currentFilters.PlanId);

            return MibSql.Default.CreateQuery(sqlBuilder).GetDataSet();
        }

        public static DataSet PlaylistPerformanceAnalytic()
        {
            ReportFilters currentFilters = ReportFilters.GetFromCookie();
            string sql = @"
            SELECT
                PLAYLIST_ID,
                NAME,
                SUM(TRAILLER) AS TRAILLER,
                SUM(MOVIE) AS MOVIE,
                SUM(RELATED) AS RELATED
            FROM
            (
                SELECT DISTINCT 
                    A.PLAYLIST_ID, 
                    PL.NAME,
                    CASE WHEN A.ACTION_ID = 27 THEN 1 ELSE 0 END AS TRAILLER,
                    CASE WHEN A.ACTION_ID = 26 AND RELATED.ACTION_ID != 26 THEN 1 ELSE 0 END AS MOVIE,
                    CASE WHEN A.ACTION_ID = 26 AND RELATED.ACTION_ID  = 26 THEN 1 ELSE 0 END AS RELATED,
                    A.ID
                FROM
                    CONTENTS (NOLOCK) AS C
                LEFT JOIN
                    DX_ANALYTICS (NOLOCK) AS A ON A.CONTENT_ID = C.ID
                LEFT JOIN
                    DX_ANALYTICS (NOLOCK) AS RELATED ON RELATED.ID = A.RELATED_ID
                LEFT JOIN
                    DX_ANALYTICS_SESSIONS (NOLOCK) AS S ON S.ID = A.SESSION_ID
                LEFT JOIN
                    DX_PLAYLISTS (NOLOCK) AS PL ON PL.ID = A.PLAYLIST_ID
                LEFT JOIN
                    DX_PROFILES (NOLOCK) AS P ON S.PROFILE_ID = P.ID
                LEFT JOIN
                    DX_KEYS (NOLOCK) AS K ON P.USERID = K.USERID
                WHERE 
                    A.ACTION_ID IN(27,26)
                    AND A.PLAYLIST_ID != 0
                    AND (S.SESSION_START BETWEEN ? AND ?)";

            if (currentFilters.PlanId != 0)
                sql += @"
                    AND K.SUBSCRIPTION_PLAN = ?";

            sql += @"
            ) SUB
            GROUP BY
                PLAYLIST_ID,
                NAME
            ORDER BY
                TRAILLER DESC";


            MibSqlBuilder sqlBuilder = new MibSqlBuilder(sql);
            sqlBuilder.AddParameter(currentFilters.StartDate);
            sqlBuilder.AddParameter(currentFilters.EndDate);
            if (currentFilters.PlanId != 0)
                sqlBuilder.AddParameter(currentFilters.PlanId);

            return MibSql.Default.CreateQuery(sqlBuilder).GetDataSet();

        }

        public static DataSet PlaylistPositionPerformanceAnalytic()
        {
            ReportFilters currentFilters = ReportFilters.GetFromCookie();
            string sql = @"
            SELECT
	            PLAYLIST_POSITION,
	            NAME,
	            SUM(TRAILLER) TRAILLER,
	            SUM(MOVIE) MOVIE,
	            SUM(RELATED) RELATED
            FROM
            (
	            SELECT DISTINCT
		            A.PLAYLIST_POSITION, 
		            PL.NAME,
		            CASE WHEN A.ACTION_ID = 27 THEN 1 ELSE 0 END AS TRAILLER,
		            CASE WHEN A.ACTION_ID = 26 AND RELATED.ACTION_ID != 26 THEN 1 ELSE 0 END AS MOVIE,
		            CASE WHEN A.ACTION_ID = 26 AND RELATED.ACTION_ID  = 26 THEN 1 ELSE 0 END AS RELATED,
		            A.ID
	            FROM
		            CONTENTS (NOLOCK) AS C
	            LEFT JOIN
		            DX_ANALYTICS  (NOLOCK) AS A ON A.CONTENT_ID = C.ID
	            LEFT JOIN
		            DX_ANALYTICS  (NOLOCK) AS RELATED ON RELATED.ID = A.RELATED_ID
	            LEFT JOIN
		            DX_ANALYTICS_SESSIONS (NOLOCK) AS S ON S.ID = A.SESSION_ID
	            LEFT JOIN
		            DX_PLAYLISTS  (NOLOCK) AS PL ON PL.ID = A.PLAYLIST_ID
	            LEFT JOIN
		            DX_PROFILES   (NOLOCK) AS P ON S.PROFILE_ID = P.ID
	            LEFT JOIN
		            DX_KEYS       (NOLOCK) AS K ON P.USERID = K.USERID
	            WHERE 
		            A.ACTION_ID IN(27,26) AND A.PLAYLIST_ID!=0
		            AND (S.SESSION_START BETWEEN ? AND ?)";

            if (currentFilters.PlanId != 0)
                sql += @"
                    AND K.SUBSCRIPTION_PLAN = ?";

            sql += @"
            ) SUB
            GROUP BY
	            PLAYLIST_POSITION,
	            NAME
            ORDER BY
	            TRAILLER DESC";

            MibSqlBuilder sqlBuilder = new MibSqlBuilder(sql);
            sqlBuilder.AddParameter(currentFilters.StartDate);
            sqlBuilder.AddParameter(currentFilters.EndDate);
            if (currentFilters.PlanId != 0)
                sqlBuilder.AddParameter(currentFilters.PlanId);

            return MibSql.Default.CreateQuery(sqlBuilder).GetDataSet();
        }

        public static DataSet LogoutInterval()
        {
            ReportFilters currentFilters = ReportFilters.GetFromCookie();
            string sql = @"SELECT
	                            AVG_PROFILE_RECURRENCE,
	                            COUNT(PROFILE_ID) TOTAL_PROFILES
                            FROM
                            (

                            SELECT
	                            AVG(DAYS) AVG_PROFILE_RECURRENCE,
	                            PROFILE_ID
                            FROM
	                            (
	                            SELECT
		                            PROFILE_ID,
		                            SESSION_END,
		                            DATEDIFF(DAY, S.SESSION_END,ISNULL((SELECT TOP 1 SESSION_END FROM DX_ANALYTICS_SESSIONS WHERE SESSION_END > S.SESSION_END AND S.PROFILE_ID=PROFILE_ID),S.SESSION_END)) AS DAYS
	                            FROM
		                            DX_ANALYTICS_SESSIONS S WITH(NOLOCK)
	                            WHERE
		                            S.PROFILE_ID IN
			                            (
				                            SELECT DISTINCT
					                            PROFILE_ID
				                            FROM
					                            DX_ANALYTICS_SESSIONS
				                            INNER JOIN
					                            DX_PROFILES
				                            ON
					                            DX_PROFILES.ID=DX_ANALYTICS_SESSIONS.PROFILE_ID
				                            INNER JOIN
					                            DX_KEYS
				                            ON
					                            DX_KEYS.USERID=DX_PROFILES.USERID
				                            WHERE
					                            SESSION_END BETWEEN ? AND ?";
             if (currentFilters.PlanId != 0)
                 sql+=@"
					                            AND DX_KEYS.SUBSCRIPTION_PLAN=?";
                 sql+=@"
			                            )
	                            ) AS T1
                            WHERE
	                            DAYS>0
                            GROUP BY
	                            PROFILE_ID
                            ) AS T2
                            GROUP BY
	                            AVG_PROFILE_RECURRENCE
                            ORDER BY
	                            AVG_PROFILE_RECURRENCE";
            MibSqlBuilder sqlBuilder = new MibSqlBuilder(sql);
            sqlBuilder.AddParameter(currentFilters.StartDate);
            sqlBuilder.AddParameter(currentFilters.EndDate);
            if (currentFilters.PlanId != 0)
                sqlBuilder.AddParameter(currentFilters.PlanId);

            return MibSql.Default.CreateQuery(sqlBuilder).GetDataSet();
        }

        public static DataSet UserBehaviourUsers()
        {
            ReportFilters currentFilters=ReportFilters.GetFromCookie();
            string Sql = @"
            SELECT
	            DXAS.ID
            FROM
	            DX_ANALYTICS_SESSIONS (NOLOCK) DXAS
            INNER JOIN
	            DX_PROFILES (NOLOCK) P
            ON
	            P.ID=DXAS.PROFILE_ID
            INNER JOIN
	            DX_KEYS (NOLOCK) KS
            ON
	            KS.USERID=P.USERID
            WHERE
	            DXAS.SESSION_START BETWEEN ? AND ?";
            if(currentFilters.PlanId!=0)
            {
                Sql+=@"
	            AND KS.SUBSCRIPTION_PLAN=?";
            }
            MibSqlBuilder SqlBuilder = new MibSqlBuilder(Sql);
            SqlBuilder.AddParameter(currentFilters.StartDate);
            SqlBuilder.AddParameter(currentFilters.EndDate);
            if (currentFilters.PlanId != 0)
            {
                SqlBuilder.AddParameter(currentFilters.PlanId);
            }
            return MibSql.Default.CreateQuery(SqlBuilder).GetDataSet();
        }

        public static DataSet UserBehaviour(int sessionId)
        {
            string Sql = @"
            SELECT
	            DXA.ACTION_ID,
	            DXA.[TIME] [FROM],
	            ISNULL((SELECT TOP 1 [TIME] FROM DX_ANALYTICS (NOLOCK) WHERE ID>DXA.ID AND SESSION_ID=DXA.SESSION_ID),(SELECT SESSION_END FROM DX_ANALYTICS_SESSIONS (NOLOCK) WHERE ID=DXA.SESSION_ID)) [TO]
            FROM
	            DX_ANALYTICS (NOLOCK) DXA
            WHERE
	            SESSION_ID=?
            ORDER BY
	            [FROM]";
            MibSqlBuilder SqlBuilder = new MibSqlBuilder(Sql);
            SqlBuilder.AddParameter(sessionId);
            return MibSql.Default.CreateQuery(SqlBuilder).GetDataSet();
        }
    }
}

    /// <summary>
    /// Enumerador para Periodo do Relatório
    /// </summary>
    public enum EReportingPeriod
    {
        Day = 1,
        Week = 7,
        Month = 30
    }

    /// <summary>
    /// Enumerador para Periodo do Relatório
    /// </summary>
    public enum EReportingPreferences
    {
        Audio = 1,
        Subtitle = 2,
        Quality = 3
    }