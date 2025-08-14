using SQLite;


namespace Teste_BTG_CRUD_Cliente.Data.Models
{
    public class BaseModel
    {
        [PrimaryKey]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Column("Dt_Inclusao")]
        public DateTime Dt_Inclusao { get; set; } = DateTime.Now;
        [Column("Dt_Alteracao")]
        public DateTime Dt_Alteracao { get; set; } = DateTime.Now;
        public bool Ativo { get; set; } = true;
    }
}
