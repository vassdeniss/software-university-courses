const sections = document.getElementsByClassName('view-section');
const nav = document.querySelector('nav');

export function showSection(section) {
  hideAll();

  //nav.insertAdjacentElement('afterend', section);

  section.style.display = 'block';
}

function hideAll() {
  Array.from(sections).forEach((section) => (section.style.display = 'none'));
}

// function hideAll() {
//   Array.from(sections).forEach((section) => section.remove());
// }
