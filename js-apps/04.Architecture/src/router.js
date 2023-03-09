const sections = document.getElementsByClassName('home');
const nav = document.querySelector('nav');

export function showSection(section) {
  hideAll();

  nav.insertAdjacentElement('afterend', section);

  //nav.insertBefore(section, nav.nextElementSibling);
}

function hideAll() {
  Array.from(sections).forEach((section) => section.remove());
}
