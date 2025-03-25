// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System.ComponentModel.DataAnnotations;
using Izkustvolandia.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Izkustvolandia.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public RegisterModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        [BindProperty]
        public InputModel Input { get; set; }
        
        public class InputModel
        {
            [Required(ErrorMessage = "Полето е задължително.")]
            [MinLength(2, ErrorMessage = "Въведи поне 2 символа.")]
            [MaxLength(100, ErrorMessage = "Въведи не повече от 100 символа.")]
            public string FirstName { get; set; }
            
            [Required(ErrorMessage = "Полето е задължително.")]
            [MinLength(2, ErrorMessage = "Въведи поне 2 символа.")]
            [MaxLength(100, ErrorMessage = "Въведи не повече от 100 символа.")]
            public string LastName { get; set; }
            
            [Required(ErrorMessage = "Полето е задължително.")]
            [EmailAddress(ErrorMessage = "Въведи валиден имейл адрес.")]
            public string Email { get; set; }
            
            [Required]
            [StringLength(100, ErrorMessage = "Паролата трябва да бъде между 6 и 100 символа.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            public string Password { get; set; }
            
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Двете пароли не съвпадат.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            var user = new User
            {
                FirstName = Input.FirstName,
                LastName = Input.LastName,
                Email = Input.Email,
                UserName = Input.Email
            };
            
            var result = await _userManager.CreateAsync(user, Input.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToPage("/");
            }
            
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return Page();
        }
    }
}