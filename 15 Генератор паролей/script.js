const lowercase = 'abcdefghijklmnopqrstuvwxyz';
const uppercase = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
const numbers = '0123456789';
const symbols = '!@#$%^&*()_+~`|}{[]:;?><,./-=';

function generatePassword() {
  const length = document.getElementById('length').value;
  const lowercaseChecked = document.getElementById('lowercase').checked;
  const uppercaseChecked = document.getElementById('uppercase').checked;
  const numbersChecked = document.getElementById('numbers').checked;
  const symbolsChecked = document.getElementById('symbols').checked;

  let characters = '';
  if (lowercaseChecked) characters += lowercase;
  if (uppercaseChecked) characters += uppercase;
  if (numbersChecked) characters += numbers;
  if (symbolsChecked) characters += symbols;

  let password = '';
  for (let i = 0; i < length; i++) {
    password += characters[Math.floor(Math.random() * characters.length)];
  }

  document.getElementById('password').textContent = password;
}
