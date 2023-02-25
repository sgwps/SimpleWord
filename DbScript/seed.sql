\connect swdb

CREATE TABLE "collections"
(
    "id" serial PRIMARY KEY,
    "source_language"  VARCHAR (3)  NOT NULL,
    "destination_language"  VARCHAR (3)  NOT NULL,
    "title"  VARCHAR (200)  NOT NULL,
    "collection_description"  VARCHAR (1000)  NOT NULL,
    "author"  VARCHAR (100),
    "link_name" VARCHAR (30) UNIQUE

);

CREATE TABLE "cards"
(
    "id" serial PRIMARY KEY,
    "collection_id" integer REFERENCES "collections",
    "word"  VARCHAR (100) NOT NULL,
    "comment"  VARCHAR (500)
);

CREATE TABLE translations
(
    "id" serial PRIMARY KEY,
    "card_id" integer REFERENCES "cards",
    "translation_value" VARCHAR (100) NOT NULL,
    "comment" VARCHAR (500)

);

CREATE TABLE examples
(
    "id" serial PRIMARY KEY,
    "translation_id" integer REFERENCES "translations",
    "origin" VARCHAR(400) NOT NULL,
    "example_translation" VARCHAR(400) NOT NULL,
    "comment" VARCHAR(500),
    "source" VARCHAR(200)
);


ALTER TABLE "collections" OWNER TO swuser;
ALTER TABLE "cards" OWNER TO swuser;
ALTER TABLE "translations" OWNER TO swuser;
ALTER TABLE "examples" OWNER TO swuser;