using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Entidades.Extensions
{
    public class ClientesExtensions
    {
        public static ClienteListDto ToClienteListDto(Cliente cliente)
        {
            return new ClienteListDto
            {
                ClienteId = cliente.ClienteId,
                Nombres = cliente.Nombres,
                Apellido = cliente.Apellido,
                Documento = cliente.Documento,
            };
        }
    }
}
