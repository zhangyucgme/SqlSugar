﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;

namespace SqlSugar
{
    public partial class QueryableProvider<T> : QueryableAccessory, ISugarQueryable<T> where T : class, new()
    {
        public SqlSugarClient Context { get; set; }
        public IDb Db { get { return Context.Database; } }
        public IDbBind Bind { get { return this.Db.DbBind; } }
        public ISqlBuilder SqlBuilder { get; set; }
        public List<SugarParameter> Pars
        {
            get { return PubMethod.IsNullReturnNew<List<SugarParameter>>(base._Pars); }
            set { base._Pars = value; }
        }

        public void Clear()
        {
            Pars = null;
            SqlBuilder.LambadaQueryBuilder.Clear();
        }

        public ISugarQueryable<T> AddParameters(object pars)
        {
            AddPars(pars, Context);
            return this;
        }
        public ISugarQueryable<T> AddParameters(SugarParameter[] pars)
        {
            AddPars(pars, Context);
            return this;
        }

        public ISugarQueryable<T> AddJoinInfo(string tableName, string shortName, string joinWhere, JoinType type = JoinType.Left)
        {

            SqlBuilder.LambadaQueryBuilder.JoinIndex = +1;
            SqlBuilder.LambadaQueryBuilder.JoinQueryInfos
                .Add(new JoinQueryInfo()
                {
                    JoinIndex = SqlBuilder.LambadaQueryBuilder.JoinIndex,
                    TableName = tableName,
                    ShortName = shortName,
                    JoinType = type,
                    JoinWhere = joinWhere
                });
            return this;
        }

        public virtual ISugarQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            var type = ResolveExpressType.WhereSingle;
            if (this.SqlBuilder.LambadaQueryBuilder.JoinQueryInfos.IsValuable())
            {
                type = ResolveExpressType.WhereMultiple;
            }
            base.Where<T>(expression, type, this.Context, this.SqlBuilder);
            return this;
        }

        public ISugarQueryable<T> Where(string whereString, object whereObj = null)
        {
            base.Where<T>(whereString, whereObj, this.Context, this.SqlBuilder);
            return this;
        }

        public ISugarQueryable<T> Where<T2>(string whereString, object whereObj = null) where T2 : class, new()
        {
            base.Where<T2>(whereString, whereObj, this.Context, this.SqlBuilder);
            return this;
        }

        public ISugarQueryable<T> Where<T2>(Expression<Func<T2, bool>> expression) where T2 : class, new()
        {
            return this;
        }
        public ISugarQueryable<T> Where<T2, T3>(Expression<Func<T2, T3, bool>> expression) where T2 : class, new() where T3 : class, new()
        {
            return this;
        }
        public ISugarQueryable<T> Where<T2, T3, T4>(Expression<Func<T2, T3, T4, bool>> expression) where T2 : class, new() where T3 : class, new() where T4 : class, new()
        {
            return this;
        }
        public ISugarQueryable<T> Where<T2, T3, T4, T5>(Expression<Func<T2, T3, T4, T5, bool>> expression) where T2 : class, new() where T3 : class, new() where T4 : class, new() where T5 : class, new()
        {
            return this;
        }
        public ISugarQueryable<T> Where<T2, T3, T4, T5, T6>(Expression<Func<T2, T3, T4, T5, T6, bool>> expression) where T2 : class, new() where T3 : class, new() where T4 : class, new() where T5 : class, new() where T6 : class, new()
        {
            return this;
        }
        public ISugarQueryable<T> In(params object[] pkValues)
        {
            throw new NotImplementedException();
        }

        public T InSingle(object pkValue)
        {
            throw new NotImplementedException();
        }

        public ISugarQueryable<T> In<FieldType>(string InFieldName, params FieldType[] inValues)
        {
            throw new NotImplementedException();
        }

        public ISugarQueryable<T> In<FieldType>(Expression<Func<T, object>> expression, params FieldType[] inValues)
        {
            throw new NotImplementedException();
        }

        public ISugarQueryable<T> In<FieldType>(Expression<Func<T, object>> expression, List<FieldType> inValues)
        {
            throw new NotImplementedException();
        }

        public ISugarQueryable<T> In<FieldType>(string InFieldName, List<FieldType> inValues)
        {
            throw new NotImplementedException();
        }

        public ISugarQueryable<T> OrderBy(string orderFileds)
        {
            throw new NotImplementedException();
        }

        public ISugarQueryable<T> OrderBy(Expression<Func<T, object>> expression, OrderByType type = OrderByType.Asc)
        {
            throw new NotImplementedException();
        }

        public ISugarQueryable<T> OrderBy<T2>(Expression<Func<T, T2, object>> expression, OrderByType type = OrderByType.Asc)
        {
            throw new NotImplementedException();
        }

        public ISugarQueryable<T> GroupBy(Expression<Func<T, object>> expression)
        {
            throw new NotImplementedException();
        }

        public ISugarQueryable<T> GroupBy(string groupFileds)
        {
            throw new NotImplementedException();
        }

        public ISugarQueryable<T> Skip(int index)
        {
            throw new NotImplementedException();
        }

        public ISugarQueryable<T> Take(int num)
        {
            throw new NotImplementedException();
        }

        public T Single()
        {
            throw new NotImplementedException();
        }

        public T SingleOrDefault()
        {
            throw new NotImplementedException();
        }

        public T Single(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public T SingleOrDefault(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public T First()
        {
            throw new NotImplementedException();
        }

        public T FirstOrDefault()
        {
            throw new NotImplementedException();
        }

        public T First(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public bool Any()
        {
            throw new NotImplementedException();
        }

        public ISugarQueryable<TResult> Select<T2, TResult>(Expression<Func<T2, TResult>> expression) where TResult : class, new()
        {
            throw new NotImplementedException();
        }

        public ISugarQueryable<TResult> Select<T2, T3, TResult>(Expression<Func<T2, T3, TResult>> expression) where TResult : class, new()
        {
            throw new NotImplementedException();
        }

        public ISugarQueryable<TResult> Select<T2, T3, T4, TResult>(Expression<Func<T2, T3, T4, TResult>> expression) where TResult : class, new()
        {
            throw new NotImplementedException();
        }

        public ISugarQueryable<TResult> Select<T2, T3, T4, T5, TResult>(Expression<Func<T2, T3, T4, T5, TResult>> expression) where TResult : class, new()
        {
            throw new NotImplementedException();
        }
        public ISugarQueryable<TResult> Select<T2, T3, T4, T5, T6, TResult>(Expression<Func<T2, T3, T4, T5, T6, TResult>> expression) where TResult : class, new()
        {
            throw new NotImplementedException();
        }
        public ISugarQueryable<TResult> Select<T2, T3, T4, T5, T6, T7, TResult>(Expression<Func<T2, T3, T4, T5, T6, T7, TResult>> expression) where TResult : class, new()
        {
            throw new NotImplementedException();
        }

        public ISugarQueryable<TResult> Select<TResult>(Expression<Func<T, TResult>> expression) where TResult : class, new()
        {
            var reval = InstanceFactory.GetQueryable<TResult>(this.Context.CurrentConnectionConfig);
            reval.Context = this.Context;
            reval.SqlBuilder = this.SqlBuilder;
            base.SetSelectType(reval.Context, this.SqlBuilder);
            SqlBuilder.LambadaQueryBuilder.SelectValue = expression;
            reval.Pars = this.Pars;
            return reval;
        }

        public ISugarQueryable<TResult> Select<TResult>(string selectValue) where TResult : class, new()
        {
            var reval = InstanceFactory.GetQueryable<TResult>(this.Context.CurrentConnectionConfig);
            reval.Context = this.Context;
            reval.SqlBuilder = this.SqlBuilder;
            base.SetSelectType(reval.Context, this.SqlBuilder);
            SqlBuilder.LambadaQueryBuilder.SelectValue = selectValue;
            reval.Pars = this.Pars;
            return reval;
        }
        public ISugarQueryable<T> Select(string selectValue)
        {
            base.SetSelectType(this.Context, this.SqlBuilder);
            SqlBuilder.LambadaQueryBuilder.SelectValue = selectValue;
            return this;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public TResult Max<TResult>(string maxField)
        {
            throw new NotImplementedException();
        }

        public object Max(Expression<Func<T, object>> expression)
        {
            throw new NotImplementedException();
        }

        public TResult Min<TResult>(string minField)
        {
            throw new NotImplementedException();
        }

        public object Min(Expression<Func<T, object>> expression)
        {
            throw new NotImplementedException();
        }

        public List<T> ToList()
        {
            string sql = SqlBuilder.LambadaQueryBuilder.ToSqlString();
            using (var dataReader = this.Db.GetDataReader(sql, this.Pars.ToArray()))
            {
                var reval = this.Bind.DataReaderToList<T>(typeof(T), dataReader, SqlBuilder.LambadaQueryBuilder.SelectCacheKey);
                return reval;
            }
        }
        public string ToJson()
        {
            throw new NotImplementedException();
        }

        public string ToJsonPage(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public string ToJsonPage(int pageIndex, int pageSize, ref int pageCount)
        {
            throw new NotImplementedException();
        }

        public KeyValuePair<string, Dictionary<string, string>> ToSql()
        {
            throw new NotImplementedException();
        }

        public DataTable ToDataTable()
        {
            throw new NotImplementedException();
        }

        public DataTable ToDataTablePage(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public DataTable ToDataTablePage(int pageIndex, int pageSize, ref int pageCount)
        {
            throw new NotImplementedException();
        }

        public List<T> ToPageList(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public List<T> ToPageList(int pageIndex, int pageSize, ref int pageCount)
        {
            throw new NotImplementedException();
        }

  
    }
}