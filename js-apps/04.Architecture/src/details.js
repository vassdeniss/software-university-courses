import { showSection } from './router.js';
import { getIdeaById, deleteIdea } from './endpoints.js';
import { createElement } from './util.js';
import { showDashboard } from './dashboard.js';

const section = document.getElementById('idea-details');

export async function showDetails(event, id) {
  event.preventDefault();

  const idea = await getIdeaById(id);
  const userData = JSON.parse(localStorage.getItem('userData'));
  const isOwner = userData && userData.id === idea._ownerId;

  section.replaceChildren(createIdeaElement(idea, isOwner));

  showSection(section);
}

function createIdeaElement(idea, isOwner) {
  const fragment = document.createDocumentFragment();

  createElement('img', '', fragment, {
    class: 'det-img',
    src: idea.img,
  });

  const desc = createElement('div', '', fragment, {
    class: 'desc',
  });

  createElement('h2', idea.title, desc, {
    class: 'display-5',
  });

  createElement('p', 'Description:', desc, {
    class: 'infoType',
  });

  createElement('p', idea.description, desc, {
    class: 'idea-description',
  });

  const div = createElement('div', '', fragment, {
    class: 'text-center',
  });

  if (isOwner) {
    const a = createElement('a', 'Delete', div, {
      class: 'btn detb',
      href: '',
    });
    a.addEventListener('click', async (event) => {
      event.preventDefault();
      await deleteIdea(idea._id);
      showDashboard();
    });
  }

  return fragment;
}
