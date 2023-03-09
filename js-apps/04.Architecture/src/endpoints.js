import { get, post, del } from './api.js';

export async function getIdeas() {
  return await get(
    '/data/ideas?select=_id%2Ctitle%2Cimg&sortBy=_createdOn%20desc'
  );
}

export async function createIdea(data) {
  try {
    if (!data.title || !data.description || !data.imageURL) {
      throw new Error('All fields are required!');
    }

    if (data.title.length < 6) {
      throw new Error('Title should be at least 6 characters long!');
    }

    if (data.description.length < 10) {
      throw new Error('Description should be at least 10 characters long!');
    }

    if (data.imageURL.length < 5) {
      throw new Error('Image should be at least 5 characters long!');
    }
  } catch (error) {
    alert(error.message);
    throw error;
  }

  await post('/data/ideas', {
    title: data.title,
    description: data.description,
    img: data.imageURL,
  });
}

export async function getIdeaById(id) {
  return await get(`/data/ideas/${id}`);
}

export async function deleteIdea(id) {
  await del(`/data/ideas/${id}`);
}
