using Bombones.Datos.Interfaces;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioClientes : IRepositorioClientes

    {
        public RepositorioClientes()
        {

        }

        public void Agregar(Cliente cliente, SqlConnection conn, SqlTransaction? tran)
        {
            string insertQuery = @"INSERT INTO Clientes 
                (Nombres, Apellido, Documento) 
                VALUES (@Nombres, @Apellido, @Documento); 
                SELECT CAST(SCOPE_IDENTITY() as int)";

            int primaryKey = conn.QuerySingle<int>(insertQuery, cliente, tran);
            if (primaryKey > 0)
            {
                cliente.ClienteId = primaryKey;
                return;
            }
            throw new Exception("No se pudo agregar el cliente");
        }

        public void Borrar(int ClienteId, SqlConnection conn, SqlTransaction? tran)
        {
            var deleteQuery = @"DELETE FROM Clientes 
                WHERE ClienteId=@ClienteId";
            int registrosAfectados = conn
                .Execute(deleteQuery, new { ClienteId }, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("No se pudo borrar el cliente");
            }
        }

        public List<ClienteListDto> GetLista(SqlConnection conn)
        {
            string selectQuery = @"SELECT ClienteId, Documento, Nombres, Apellido FROM Clientes";
            return conn.Query<ClienteListDto>(selectQuery).ToList();
        }
    }
}
