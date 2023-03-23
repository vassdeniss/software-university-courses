export function addQuery(ctx, next) {
  ctx.query = ctx.queryString
    ? Object.fromEntries(ctx.queryString.split('&').map((el) => el.split('=')))
    : {};

  next();
}
