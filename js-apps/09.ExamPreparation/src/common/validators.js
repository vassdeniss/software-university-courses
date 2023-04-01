export function isValidBook(book) {
  if (!book.title || !book.description || !book.imageUrl || !book.type) {
    return false;
  }

  return true;
}
