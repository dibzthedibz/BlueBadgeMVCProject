﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTMVC.Data;
using WOTMVC.Models.NationMods;

namespace WOTMVC.Services
{
    public class NationService
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        private readonly Guid _userId;
        public NationService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<NationListItem> GetNations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Nations.Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new NationListItem
                        {
                            NationId = e.NationId,
                            NationName = e.NationName,
                            Terrain = e.Terrain,
                            Trades = e.Trades
                        }
                    );
                return query.ToArray();
            }
        }
        public bool CreateNation(NationCreate model)
        {
            var entity = new Nation()
            {
                OwnerId = _userId,
                NationName = model.NationName,
                Terrain = model.Terrain,
                Trades = model.Trades
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Nations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public NationDetail GetNationById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Nations.Single(e => e.NationId == id && e.OwnerId == _userId);
                return new NationDetail
                {
                    NationId = entity.NationId,
                    NationName = entity.NationName,
                    Terrain = entity.Terrain,
                    Trades = entity.Trades
                };
            }
        }
        public bool UpdateNation(NationEdit nation)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Nations
                        .Single(e => e.NationId == nation.NationId && e.OwnerId == _userId);
                entity.NationName = nation.NationName;
                entity.Terrain = nation.Terrain;
                entity.Trades = nation.Trades;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteNation(int nationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Nations
                        .Single(e => e.NationId == nationId && e.OwnerId == _userId);

                ctx.Nations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
