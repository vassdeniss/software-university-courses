import { get, post, put, del } from './api.js';

export async function createMovie(data) {
  try {
    if (!data.title || !data.description || !data.img) {
      throw new Error('All fields are required!');
    }
  } catch (error) {
    alert(error.message);
    throw error;
  }

  await post('/data/movies', data);
}

export async function getMovies() {
  return await get('/data/movies');
}

export async function getMovieById(id) {
  return await get(`/data/movies/${id}`);
}

export async function getMovieLikes(id) {
  return await get(
    `/data/likes?where=movieId%3D%22${id}%22&distinct=_ownerId&count`
  );
}

export async function editMovie(data) {
  try {
    if (!data.title || !data.description || !data.img) {
      throw new Error('All fields are required!');
    }
  } catch (error) {
    alert(error.message);
    throw error;
  }

  await put(`/data/movies/${data.id}`, data);
}

export async function likeMovie(id) {
  await post('/data/likes', {
    movieId: id,
  });
}

export async function hasUserLikedMovie(movieId, userId) {
  const result = await get(
    `/data/likes?where=movieId%3D%22${movieId}%22%20and%20_ownerId%3D%22${userId}%22`
  );

  return result.length > 0;
}

export async function deleteMovie(id) {
  await del(`/data/movies/${id}`);
}
