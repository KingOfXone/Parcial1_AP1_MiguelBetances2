using Microsoft.EntityFrameworkCore;
using Parcial1_AP1_MiguelBetances.Components;
using Parcial1_AP1_MiguelBetances.Components.DAL;
using Parcial1_AP1_MiguelBetances.Models;
using System.Linq.Expressions;


namespace Parcial1_AP1_MiguelBetances.Service
{
    public class MetasService
    {
        private readonly Context _contexto;

        public MetasService(Context contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Insertar(Metas metas)
        {
            _contexto.Metas.Add(metas);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Metas metas)
        {
            var a = await _contexto.Metas.FindAsync(metas.MetasId);
            _contexto.Entry(a!).State = EntityState.Detached;
            _contexto.Entry(metas).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Existe(int metaId)
        {
            return await _contexto.Metas
                .AnyAsync(a => a.MetasId == metaId);
        }

        public async Task<bool> Guardar(Metas metas)
        {
            if (!await Existe(metas.MetasId))
                return await Insertar(metas);
            else
                return await Modificar(metas);
        }

        public async Task<bool> Eliminar(Metas metas)
        {
            var cantidad = await _contexto.Metas
                 .Where(a => a.MetasId == metas.MetasId)
                 .ExecuteDeleteAsync();
            return cantidad > 0;
        }


        public async Task<Metas?> Buscar(int metaId)
        {
            return await _contexto.Metas
                .Where(a => a.MetasId == metaId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public List<Metas> Listar(Expression<Func<Metas, bool>> criterio)
        {
            return _contexto.Metas
                .Where(criterio)
                .AsNoTracking()
                .ToList();
        }
    }
}


