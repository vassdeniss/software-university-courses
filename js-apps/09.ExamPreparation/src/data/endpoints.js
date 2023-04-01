import { del, get, post, put } from './api.js';

const endpoints = {
  books: '/data/books',
  sortedBooks: '/data/books?sortBy=_createdOn%20desc',
  likes: '/data/likes',
};

export async function getBooks() {
  return await get(endpoints.sortedBooks);
}

export async function createBook(book) {
  return await post(endpoints.books, {
    title: book.title,
    description: book.description,
    imageUrl: book.imageUrl,
    type: book.type,
  });
}

export async function getBookById(id) {
  return await get(`${endpoints.books}/${id}`);
}

export async function deleteBook(id) {
  return await del(`${endpoints.books}/${id}`);
}

export async function editBook(book, id) {
  return await put(`${endpoints.books}/${id}`, {
    title: book.title,
    description: book.description,
    imageUrl: book.imageUrl,
    type: book.type,
  });
}

export async function getUserBooks(id) {
  return await get(
    `${endpoints.books}?where=_ownerId%3D%22${id}%22&sortBy=_createdOn%20desc`
  );
}

export async function getBookLikes(id) {
  return await get(
    `${endpoints.likes}?where=bookId%3D%22${id}%22&distinct=_ownerId&count`
  );
}

export async function getLikeForUser(bookId, userId) {
  return await get(
    `${endpoints.likes}?where=bookId%3D%22${bookId}%22%20and%20_ownerId%3D%22${userId}%22&count`
  );
}

export async function likeBookById(bookId) {
  return await post(endpoints.likes, {
    bookId,
  });
}
