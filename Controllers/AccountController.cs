using Microsoft.AspNetCore.Mvc;
using WtLab4Korbut.Models;

namespace WtLab4Korbut.Controllers;

public class AccountController : Controller
{
    // Данные хранятся в памяти (статический список)
    private static List<Account> _accounts = new List<Account>
    {
        new Account { Id = 1, Number = "BY01-0001", OwnerName = "Моргенштерн И.И.", Type = AccountType.Savings, Balance = 1400m, InterestRate = 0.05m, IsActive = true },
        new Account { Id = 2, Number = "BY02-0002", OwnerName = "Искусственный Интеллект А.С.", Type = AccountType.Checking, Balance = 450m, InterestRate = 0.005m, IsActive = true },
        new Account { Id = 3, Number = "BY03-0003", OwnerName = "Кишиба Рохан", Type = AccountType.Deposit, Balance = 7000m, InterestRate = 0.12m, IsActive = true },
        new Account { Id = 4, Number = "BY01-0004", OwnerName = "Искусственный Интеллект А.С.", Type = AccountType.Savings, Balance = 300m, InterestRate = 0.05m, IsActive = true },
        new Account { Id = 5, Number = "BY02-0005", OwnerName = "Моргенштерн И.И.", Type = AccountType.Checking, Balance = 2500m, InterestRate = 0.005m, IsActive = true }
    };

    // GET: /Account/Index
    public IActionResult Index()
    {
        return View(_accounts);
    }

    // GET: /Account/Details/5
    public IActionResult Details(int id)
    {
        var account = _accounts.FirstOrDefault(a => a.Id == id);
        if (account == null) return NotFound();
        return View(account);
    }

    // GET: /Account/Create
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Account/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Account account)
    {
        if (ModelState.IsValid)
        {
            account.Id = _accounts.Any() ? _accounts.Max(a => a.Id) + 1 : 1;
            account.IsActive = true;
            _accounts.Add(account);
            return RedirectToAction(nameof(Index));
        }
        return View(account);
    }

    // GET: /Account/Edit/5
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var account = _accounts.FirstOrDefault(a => a.Id == id);
        if (account == null) return NotFound();
        return View(account);
    }

    // POST: /Account/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Account account)
    {
        if (ModelState.IsValid)
        {
            var existing = _accounts.FirstOrDefault(a => a.Id == account.Id);
            if (existing == null) return NotFound();

            existing.Number = account.Number;
            existing.OwnerName = account.OwnerName;
            existing.Type = account.Type;
            existing.Balance = account.Balance;
            existing.InterestRate = account.InterestRate;
            existing.IsActive = account.IsActive;

            return RedirectToAction(nameof(Index));
        }
        return View(account);
    }

    // POST: /Account/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var account = _accounts.FirstOrDefault(a => a.Id == id);
        if (account != null)
        {
            _accounts.Remove(account);
        }
        return RedirectToAction(nameof(Index));
    }

    // Дополнительно: поиск по владельцу
    public IActionResult Search(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            return View("Index", _accounts);

        var result = _accounts
            .Where(a => a.OwnerName.Contains(query, StringComparison.OrdinalIgnoreCase))
            .ToList();

        ViewBag.Query = query;
        return View("Index", result);
    }
}
