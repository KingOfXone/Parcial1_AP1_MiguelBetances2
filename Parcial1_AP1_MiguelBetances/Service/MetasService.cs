using Microsoft.EntityFrameworkCore;
using Parcial1_AP1_MiguelBetances.Components;
using Parcial1_AP1_MiguelBetances.Components.DAL;
using Parcial1_AP1_MiguelBetances.Models;
using System.Linq.Expressions;


namespace Parcial1_AP1_MiguelBetances.Service
{
    public class MetasService
    {
            private readonly Context _context;

            public MetasService(Context context)
            {
                _context = context;
            }

            public bool Existe(int id)
            {
                return _context.Metas.Any(a => a.MetasId == id);
            }

            public bool Insertar(Metas metas)
            {
                if (metas != null)
                {
                    _context.Metas.Add(metas);
                    return _context.SaveChanges() > 0;
                }
                return false;
            }

            public bool Modificar(Metas metas)
            {
                if (metas != null)
                {
                    _context.Entry(metas).State = EntityState.Modified;
                    return _context.SaveChanges() > 0;
                }
                return false;
            }

            public bool Guardar(Metas metas)
            {
                if (Existe(metas.MetasId))
                    return Modificar(metas);
                else
                    return Insertar(metas);
            }

            public bool Eliminar(Metas metas)
            {
                _context.Entry(metas).State = EntityState.Deleted;
                return _context.SaveChanges() > 0;
            }

            public Metas? Buscar(int id)
            {
                return _context.Metas.AsNoTracking().Where(a => a.MetasId == id).SingleOrDefault();
            }

            public List<Metas> GetList(Expression<Func<Metas, bool>> criterio)
            {
                return _context.Metas.AsNoTracking().Where(criterio).ToList();
            }
        }
    }


