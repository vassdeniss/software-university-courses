import { showSection } from './router.js';
import { updatePageForUser } from './util.js';

const section = document.getElementById('get-started');

export async function showHome() {
  updatePageForUser();
  showSection(section);
}
