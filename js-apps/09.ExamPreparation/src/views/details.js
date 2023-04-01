import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import {
  getBookById,
  deleteBook,
  getBookLikes,
  getLikeForUser,
  likeBookById,
} from '../data/endpoints.js';
import { getUser } from '../util.js';

export async function renderDetails(ctx) {
  const id = ctx.params.id;

  const user = getUser();
  const [book, likes] = await Promise.all([getBookById(id), getBookLikes(id)]);

  book.hasUserLiked =
    user !== null ? (await getLikeForUser(id, user._id)) > 0 : false;
  book.isSignedIn = user !== null;
  book.isOwner = user && user._id === book._ownerId;
  book.likes = likes;

  ctx.render(detailsTemplate(book, removeBook, likeBook));

  async function removeBook() {
    if (confirm('Are you sure you want to delete this book?')) {
      await deleteBook(id);
      ctx.page.redirect('/');
    }
  }

  async function likeBook() {
    await likeBookById(id);
    book.hasUserLiked = true;
    book.likes = await getBookLikes(id);
    ctx.render(detailsTemplate(book, removeBook, likeBook));
  }
}

const detailsTemplate = (book, removeBook, likeBook) => html`<section
  id="details-page"
  class="details"
>
  <div class="book-information">
    <h3>${book.title}</h3>
    <p class="type">Type: ${book.type}</p>
    <p class="img"><img src=${book.imageUrl} /></p>
    <div class="actions">
      ${book.isOwner
        ? html`<a class="button" href="/edit/${book._id}">Edit</a>
            <a @click=${removeBook} class="button" href="javascript:void(0)"
              >Delete</a
            >`
        : nothing}
      ${book.isSignedIn && !book.isOwner && !book.hasUserLiked
        ? html`<a @click=${likeBook} class="button" href="javascript:void(0)"
            >Like</a
          >`
        : nothing}
      <div class="likes">
        <img class="hearts" src="/images/heart.png" />
        <span id="total-likes">Likes: ${book.likes}</span>
      </div>
    </div>
  </div>
  <div class="book-description">
    <h3>Description:</h3>
    <p>${book.description}</p>
  </div>
</section>`;
