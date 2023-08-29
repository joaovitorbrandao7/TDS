namespace AtividadeAPI1.API.Model
{
    public class TaskModel
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set;

        }

        public TaskModel(int id, string nome, decimal preco, int quantidade) {
        
            Id = id;
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }

    }
}
