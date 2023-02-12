function solution() {
  class Post {
    constructor(title, content) {
      this.title = title;
      this.content = content;
    }

    toString() {
      return `Post: ${this.title}\nContent: ${this.content}`;
    }
  }

  class SocialMediaPost extends Post {
    constructor(title, content, likes, dislikes) {
      super(title, content);

      this.likes = likes;
      this.dislikes = dislikes;
      this.comments = [];
    }

    addComment(comment) {
      this.comments.push(comment);
    }

    toString() {
      const result = [
        super.toString(),
        `Rating: ${this.likes - this.dislikes}`,
      ];

      if (this.comments.length > 0) {
        result.push('Comments:');
        this.comments.forEach((comment) => result.push(` * ${comment}`));
      }

      return result.join('\n');
    }
  }

  class BlogPost extends Post {
    constructor(title, content, views) {
      super(title, content);

      this.views = views;
    }

    view() {
      this.views++;
      return this;
    }

    toString() {
      return `${super.toString()}\nViews: ${this.views}`;
    }
  }

  return {
    Post,
    SocialMediaPost,
    BlogPost,
  };
}
