using System.Collections.Generic;
using System.Linq;
using NHibernate;

namespace MusicSearch.Core.Data
{
    public static class NHibernateExtensions
    {
        /// <summary>
        /// Procedures the list.
        /// </summary>
        /// <typeparam name="TParameters">The type of the t parameters.</typeparam>
        /// <typeparam name="TReturn">The type of the t return.</typeparam>
        /// <param name="session">The session.</param>
        /// <param name="procedure">The procedure.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>List&lt;TReturn&gt;.</returns>
        public static IList<TReturn> ProcedureList<TParameters, TReturn>(this ISession session, string procedure, TParameters parameters) where TParameters : class
        {
            var query = SqlQuery<TParameters, TReturn>(session, procedure, parameters);
            return query.List<TReturn>();
        }

        /// <summary>
        /// Procedures the single.
        /// </summary>
        /// <typeparam name="TParameters">The type of the t parameters.</typeparam>
        /// <typeparam name="TReturn">The type of the t return.</typeparam>
        /// <param name="session">The session.</param>
        /// <param name="procedure">The procedure.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>TReturn.</returns>
        public static TReturn ProcedureSingle<TParameters, TReturn>(this ISession session, string procedure, TParameters parameters) where TParameters : class
        {
            var query = SqlQuery<TParameters, TReturn>(session, procedure, parameters);
            return query.UniqueResult<TReturn>();
        }

        /// <summary>
        /// SQLs the query.
        /// </summary>
        /// <typeparam name="TParameters">The type of the t parameters.</typeparam>
        /// <typeparam name="TReturn">The type of the t return.</typeparam>
        /// <param name="session">The session.</param>
        /// <param name="procedure">The procedure.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>ISQLQuery.</returns>
        private static ISQLQuery SqlQuery<TParameters, TReturn>(ISession session, string procedure, TParameters parameters)
            where TParameters : class
        {
            var properties = parameters.GetType().GetProperties();

            string[] parameterNames = properties.Select(s => string.Format(":{0}", s.Name)).ToArray();
            string procedureWithParameters = string.Format("{0} {1}", procedure, string.Join(",", parameterNames));

            var query = session.CreateSQLQuery(procedureWithParameters).AddEntity(typeof(TReturn));

            foreach (var property in properties)
            {
                query.SetParameter(property.Name, property.GetValue(parameters));
            }
            return query;
        }
    }
}
