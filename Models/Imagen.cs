using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Tarea1._4_AndreaCastro.Models
{
    public class Imagen
    {
        [PrimaryKey, AutoIncrement]
        public int id_imagen { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public byte[] Image { get; set; }
    }
}
