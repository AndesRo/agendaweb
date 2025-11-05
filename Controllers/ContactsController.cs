using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendaWeb.Data;
using AgendaWeb.Models;

namespace AgendaWeb.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Contacts
        public async Task<IActionResult> Index(string searchString)
        {
            var contacts = from c in _context.Contacts
                           select c;

            if (!string.IsNullOrEmpty(searchString))
            {
                contacts = contacts.Where(c => c.Name.Contains(searchString) || c.Email.Contains(searchString));
            }

            return View(await contacts.OrderBy(c => c.Name).ToListAsync());
        }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                TempData["ErrorMessage"] = "No se pudo encontrar el contacto solicitado.";
                return RedirectToAction(nameof(Index));
            }

            var contact = await _context.Contacts.FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                TempData["ErrorMessage"] = "El contacto no existe.";
                return RedirectToAction(nameof(Index));
            }

            return View(contact);
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Phone,Email,Notes")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.Id = Guid.NewGuid();
                contact.CreatedAt = DateTime.Now;
                _context.Add(contact);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Contacto agregado exitosamente.";
                return RedirectToAction(nameof(Index));
            }

            TempData["ErrorMessage"] = "Error al crear el contacto. Verifique los datos.";
            return View(contact);
        }

        // GET: Contacts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                TempData["ErrorMessage"] = "No se encontró el contacto.";
                return RedirectToAction(nameof(Index));
            }

            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                TempData["ErrorMessage"] = "El contacto no existe.";
                return RedirectToAction(nameof(Index));
            }

            return View(contact);
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Phone,Email,Notes,CreatedAt")] Contact contact)
        {
            if (id != contact.Id)
            {
                TempData["ErrorMessage"] = "Error de identificación del contacto.";
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Contacto actualizado correctamente.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Contacts.Any(e => e.Id == contact.Id))
                    {
                        TempData["ErrorMessage"] = "El contacto no existe o fue eliminado.";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            TempData["ErrorMessage"] = "Error al actualizar el contacto.";
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                TempData["ErrorMessage"] = "No se pudo eliminar. ID inválido.";
                return RedirectToAction(nameof(Index));
            }

            var contact = await _context.Contacts.FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                TempData["ErrorMessage"] = "El contacto no existe.";
                return RedirectToAction(nameof(Index));
            }

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                TempData["ErrorMessage"] = "El contacto ya fue eliminado o no existe.";
                return RedirectToAction(nameof(Index));
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Contacto eliminado exitosamente.";
            return RedirectToAction(nameof(Index));
        }
    }
}
