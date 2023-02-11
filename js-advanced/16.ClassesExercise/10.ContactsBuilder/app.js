class Contact {
  #online;

  constructor(firstName, lastName, phone, email) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.phone = phone;
    this.email = email;
    this.#online = false;
  }

  get online() {
    return this.#online;
  }

  set online(value) {
    this.#online = value;

    const div = Array.from(document.getElementsByClassName('title')).find(
      (el) => el.textContent.includes(`${this.firstName} ${this.lastName}`)
    );

    if (!div) {
      return;
    }

    if (value === false) {
      div.classList.remove('online');
    } else {
      div.classList.add('online');
    }
  }

  render(id) {
    const article = document.createElement('article');

    const divTitle = document.createElement('div');
    divTitle.classList.add('title');

    if (this.#online) {
      divTitle.classList.add('online');
    }

    divTitle.textContent = `${this.firstName} ${this.lastName}`;

    const button = document.createElement('button');
    button.innerHTML = '&#8505;';
    button.addEventListener('click', () => {
      divInfo.style.display =
        divInfo.style.display == 'none' ? 'block' : 'none';
    });

    const divInfo = document.createElement('div');
    divInfo.classList.add('info');
    divInfo.style.display = 'none';

    const phoneSpan = document.createElement('span');
    phoneSpan.innerHTML = `&phone; ${this.phone}`;

    const emailSpan = document.createElement('span');
    emailSpan.innerHTML = `&#9993; ${this.email}`;

    divInfo.appendChild(phoneSpan);
    divInfo.appendChild(emailSpan);

    divTitle.appendChild(button);

    article.appendChild(divTitle);
    article.appendChild(divInfo);

    document.getElementById(id).appendChild(article);
  }
}

let contacts = [
  new Contact('Ivan', 'Ivanov', '0888 123 456', 'i.ivanov@gmail.com'),
  new Contact('Maria', 'Petrova', '0899 987 654', 'mar4eto@abv.bg'),
  new Contact('Jordan', 'Kirov', '0988 456 789', 'jordk@gmail.com'),
];

contacts.forEach((contact) => contact.render('main'));

// After 1 second, change the online status to true
setTimeout(() => (contacts[1].online = true), 2000);
