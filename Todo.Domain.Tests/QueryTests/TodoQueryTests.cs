using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests
{
    [TestClass]
    public class TodoQueryTests
    {
        private List<TodoItem> _items;

        public TodoQueryTests()
        {
            _items = new List<TodoItem>();
            _items.Add( new TodoItem( "Tarefa 1", "usuarioA", DateTime.Now ) );
            _items.Add( new TodoItem( "Tarefa 2", "usuarioA", DateTime.Now ) );
            _items.Add( new TodoItem( "Tarefa 3", "andrefredjunior", DateTime.Now ) );
            _items.Add( new TodoItem( "Tarefa 4", "usuarioA", DateTime.Now ) );
            _items.Add( new TodoItem( "Tarefa 5", "andrefredjunior", DateTime.Now ) );
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_apenas_do_usuario_andrefredjunior()
        {
            var result = _items.AsQueryable().Where( TodoQueries.GetAll( "andrefredjunior" ) );
            Assert.AreEqual( 2, result.Count() );
        }
    }
}
