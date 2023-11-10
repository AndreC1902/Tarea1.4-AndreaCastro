using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea1._4_AndreaCastro.Models;

namespace Tarea1._4_AndreaCastro.Controllers
{
    public class DBImagen
    {
        readonly SQLiteAsyncConnection dbImage;
        public DBImagen(string Path)
        {
            try
            {
                dbImage = new SQLiteAsyncConnection(Path);
                //Creación de las tablas en la BD 
                dbImage.CreateTableAsync<Imagen>().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        /* CRUD de la DB Sitios */
        public Task<int> GuardarImagen(Imagen imagen)
        {
            if (imagen.id_imagen != 0)
            {
                return dbImage.UpdateAsync(imagen); //Actualización
            }
            else
            {
                return dbImage.InsertAsync(imagen); //Inserción
            }
        }

        //Lectura
        public Task<List<Imagen>> ObtenerlistaImagen()
        {
            return dbImage.Table<Imagen>().ToListAsync();
        }

        //LecturaID
        public Task<Imagen> ObtenerImagenID(int id)
        {
            return dbImage.Table<Imagen>().Where(p => p.id_imagen == id).FirstOrDefaultAsync();
        }

    }
}
