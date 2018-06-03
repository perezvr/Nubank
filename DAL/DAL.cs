using ArmazemModel.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmazemModel.DAL
{
    public class DAL<T> : IDAL<T> where T : class
    {
        public NubankContext Contexto;

        protected DAL()
        {
            Contexto = new NubankContext();
            //Contexto.Configuration.AutoDetectChangesEnabled = false;
            //Contexto.Configuration.EnsureTransactionsForFunctionsAndCommands = false;
            //Contexto.Configuration.LazyLoadingEnabled = false;
            //Contexto.Configuration.ProxyCreationEnabled = false;
            Contexto.Configuration.UseDatabaseNullSemantics = false;
            Contexto.Configuration.ValidateOnSaveEnabled = false;
        }

        /// <summary>
        /// Adiciona um objeto no banco de dados
        /// </summary>
        /// <param name="objeto">Objeto a ser incluído no banco de dados</param>
        public void Add(T objeto)
        {
            Contexto.Set<T>().Add(objeto);
            Contexto.SaveChanges();
        }

        /// <summary>
        /// Adiciona um objeto no banco de dados dentro de um contexto já existente
        /// </summary>
        /// <param name="objeto">Objeto a ser incluído no banco de dados</param>
        /// <param name="contexto">Contexto de entidades</param>
        public void Add(T objeto, NubankContext contexto)
        {
            Contexto = contexto;

            Contexto.Set<T>().Add(objeto);
            Contexto.SaveChanges();
        }

        /// <summary>
        /// Remove do banco de dados objetos que correspondam à expressão
        /// </summary>
        /// <param name="expressao">Expressão utilizada para filtrar itens a serem excluídos</param>
        public void Delete(Func<T, bool> expressao)
        {
            Contexto.Set<T>().RemoveRange(Contexto.Set<T>().Where(expressao));
            Contexto.SaveChanges();
        }

        /// <summary>
        /// Remove do banco de dados objetos que correspondam à expressão dentro de um contexto já existente
        /// </summary>
        /// <param name="expressao">Expressão utilizada para filtrar itens a serem excluídos</param>
        /// <param name="contexto">Contexto de entidades</param>
        public void Delete(Func<T, bool> expressao, NubankContext contexto)
        {
            Contexto = contexto;

            Contexto.Set<T>().RemoveRange(Contexto.Set<T>().Where(expressao));
            Contexto.SaveChanges();
        }

        /// <summary>
        /// Procura um objeto no banco de dados pela chave primária
        /// </summary>
        /// <param name="id">Chave primária</param>
        /// <returns>Objeto encontrado pela chave primária</returns>
        public T FindById(int id)
        {
            return Contexto.Set<T>().Find(id);
        }

        /// <summary>
        /// Atualiza um registro no banco de dados
        /// </summary>
        /// <param name="objeto">Objeto a ser atualizado no banco de dados</param>
        public void Update(T objeto)
        {
            Contexto.Entry(objeto).State = EntityState.Modified;
            Contexto.SaveChanges();
        }

        /// <summary>
        /// Atualiza um registro no banco de dados dentro de um contexto já existente
        /// </summary>
        /// <param name="objeto">Objeto a ser atualizado no banco de dados</param>
        /// <param name="contexto">Contexto de entidades</param>
        public void Update(T objeto, NubankContext contexto)
        {
            Contexto = contexto;

            Contexto.Entry(objeto).State = EntityState.Modified;
            Contexto.SaveChanges();
        }

        /// <summary>
        /// Retorna uma lista de objetos que correspondam à expressão
        /// </summary>
        /// <param name="expressao">Expressão utilizada para filtrar itens a serem listados</param>
        /// <returns>Lista de objetos</returns>
        public List<T> GetList(Func<T, bool> expressao)
        {
            return Contexto.Set<T>().Where(expressao).ToList();
        }

        /// <summary>
        /// Retorna o primeiro objeto que corresponda à expressão
        /// </summary>
        /// <param name="predicate">Expressão utilizada para filtrar o objeto</param>
        /// <returns>Objeto</returns>
        public T Get(Func<T, bool> predicate)
        {
            return Contexto.Set<T>().Where(predicate).FirstOrDefault();
        }

        /// <summary>
        /// Retorna o primeiro objeto que corresponda à expressão, forçando a pegar do banco de dados.
        /// </summary>
        /// <param name="predicate">Expressão utilizada para filtrar o objeto</param>
        /// <returns>Objeto</returns>
        public T GetDB(Func<T, bool> predicate)
        {
            return Contexto.Set<T>().AsNoTracking().Where(predicate).FirstOrDefault();
        }

        /// <summary>
        /// Retorna lista com todos os objetos.
        /// </summary>
        /// <returns>Lista de objetos</returns>
        public IQueryable<T> GetAll()
        {
            return Contexto.Set<T>();
        }

        /// <summary>
        /// Retorna lista com todos os objetos, forçando a pegar do banco de dados.
        /// </summary>
        /// <returns>Lista de objetos</returns>
        public IQueryable<T> GetAllDB()
        {
            return Contexto.Set<T>().AsNoTracking();
        }

        /// <summary>
        /// Seta o contexto para utilização em transações.
        /// </summary>
        /// <param name="contexto"></param>
        public void SetContext(NubankContext contexto)
        {
            Contexto = contexto;
        }
    }
}
