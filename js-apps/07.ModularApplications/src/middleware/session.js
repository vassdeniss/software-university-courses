import { getUser } from '../util.js';

export function addSession(ctx, next) {
  const user = getUser();
  ctx.user = user;
  next();
}
