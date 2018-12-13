let Parser = require("rss-parser");
let parser = new Parser();

async () => {
  let feed = await parser.parseURL(
    "https://news.google.com/news/rss/headlines/section/topic/POLITICS?ned=us&hl=en&gl=US"
  );
  console.log(feed.title);

  feed.items.forEach(item => {
    console.log(item.title + ":" + item.link);
  });
};
