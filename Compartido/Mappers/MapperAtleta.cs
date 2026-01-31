using Compartido.DTOs.Atletas;
using Compartido.DTOs.Disciplina;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.ExcepcionesEntidades.Atleta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public class MapperAtleta
    {
        public static IEnumerable<AtletaListadoDTO> ListAtletaToListAtletaDTO(List<Atleta> atletas)
        {
            IEnumerable<AtletaListadoDTO> atletasDtos = atletas.Select(u =>
            new AtletaListadoDTO()
            {
                NombreCompleto = u.NombreCompleto,
                Sexo = (int)u.Sexo,
                Pais = u.Pais.NombrePais,
                Id = u.Id,
                Disciplinas = u.Disciplinas.Select(d => new DisciplinaListadoDTO
                {
                    Nombre = d.Nombre.Valor,
                    AñoIngreso = d.AñoIngreso
                }).ToList()
            });
            return atletasDtos;
        }
        public static AtletaDetalleDTO AtletaToAtletaDetalleDTO(Atleta atleta)
        {
            if (atleta == null)
            {
                throw new AtletaException("Los datos no son correctos");
            }
            return new AtletaDetalleDTO()
            {
                NombreCompleto = atleta.NombreCompleto,
                Sexo = (int)atleta.Sexo,
                Id = atleta.Id,
                Pais = atleta.Pais.NombrePais,
                Disciplinas = atleta.Disciplinas.Select(d => new DisciplinaListadoDTO
                {
                    Nombre = d.Nombre.Valor,
                    AñoIngreso = d.AñoIngreso
                }).ToList()
            };
        }
    }
}
