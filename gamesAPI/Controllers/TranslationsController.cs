using gamesAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gamesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslationsController : ControllerBase
    {
        private readonly TransDbContext transDbContext;

        public TranslationsController(TransDbContext transDbContext)
        {
            this.transDbContext = transDbContext;
        }

        [HttpGet]
        [Route("getTranslations")]
        public async Task<IEnumerable<Translations>> getTranslations()
        {
            return await transDbContext.Translations.ToListAsync();
        }

        [HttpGet]
        [Route("getTranslations/{id}")]
        public async Task<ActionResult<Translations>> getTranslationsID(int id)
        {
            if(transDbContext.Translations == null)
            {
                return NotFound();
            }
            var trans = await transDbContext.Translations.FindAsync(id);
            if(trans == null) {
            return NotFound();
            }
            return trans;
        }

        [HttpPost]
        [Route("addTranslation")]
        public async Task <Translations> addTranslation(Translations translationsobj)
        {
            transDbContext.Translations.Add(translationsobj);
            await transDbContext.SaveChangesAsync();
            return translationsobj;
        }

        [HttpPatch]
        [Route("updateTranslation/{id}")]
        public async Task<Translations> updateTranslation(Translations translationsobj)
        {
            transDbContext.Entry(translationsobj).State = EntityState.Modified;
            await transDbContext.SaveChangesAsync();
            return translationsobj;
        }

        [HttpDelete]
        [Route("deleteTranslation/{id}")]
        public bool deleteTranslation(int id)
        {
            bool a = false;
            var translation = transDbContext.Translations.Find(id);
            if (translation != null)
            {
                a = true;
                transDbContext.Entry(translation).State = EntityState.Deleted;
                transDbContext.SaveChanges();
            }
            else
            {
                a= false;
            }

            return a;

        }


    }
}
