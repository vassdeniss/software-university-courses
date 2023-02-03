function solution(action) {
  if (action === 'upvote') {
    this.upvotes++;
    return;
  }

  if (action === 'downvote') {
    this.downvotes++;
    return;
  }

  const { upvotes, downvotes } = this;

  let rating = '';
  const balance = upvotes - downvotes;
  const total = upvotes + downvotes;
  if (total < 10) {
    rating = 'new';
  } else if (upvotes > total * 0.66) {
    rating = 'hot';
  } else if (balance >= 0 && total > 100) {
    rating = 'controversial';
  } else if (balance < 0) {
    rating = 'unpopular';
  } else {
    rating = 'new';
  }

  const obfuscated = Math.ceil(0.25 * Math.max(upvotes, downvotes));
  return total > 50
    ? [upvotes + obfuscated, downvotes + obfuscated, balance, rating]
    : [upvotes, downvotes, balance, rating];
}

let post = {
  id: '3',
  author: 'emil',
  content: 'wazaaaaa',
  upvotes: 100,
  downvotes: 100,
};

solution.call(post, 'upvote');
solution.call(post, 'downvote');
let score = solution.call(post, 'score');
solution.call(post, 'downvote');
score = solution.call(post, 'score');
