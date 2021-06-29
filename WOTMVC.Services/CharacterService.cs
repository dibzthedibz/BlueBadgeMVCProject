using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTMVC.Data;
using WOTMVC.Models.CharacterMods;

namespace WOTMVC.Services
{
    public class CharacterService
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        private readonly Guid _userId;
        public CharacterService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCharacter(CharacterCreate model)
        {
            var entity = new Character()
            {
                OwnerId = _userId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Ability = model.Ability
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Characters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CharacterListItem> GetCharacters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Characters.Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new CharacterListItem
                        {
                            CharacterId = e.CharacterId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            Ability = e.Ability,
                        }
                    );
                return query.ToArray();
            }
        }
        public CharacterDetail GetCharacterById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Characters.Single(e => e.CharacterId == id && e.OwnerId == _userId);
                return new CharacterDetail
                {
                    CharacterId = entity.CharacterId,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Ability = entity.Ability
                };
            }
        }
        public bool UpdateCharacter(CharacterEdit character)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Characters
                        .Single(e => e.CharacterId == character.CharacterId && e.OwnerId == _userId);
                entity.FirstName = character.FirstName;
                entity.LastName = character.LastName;
                entity.Ability = character.Ability;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCharacter(int characterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Characters
                        .Single(e => e.CharacterId == characterId && e.OwnerId == _userId);

                ctx.Characters.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
