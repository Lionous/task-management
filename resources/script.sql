PRAGMA foreign_keys = ON;

CREATE TABLE "categories" (
    "id" TEXT,
    "name" TEXT NOT NULL,
    PRIMARY KEY("id")
);

CREATE TABLE "tasks" (
    "id" TEXT,
    "title" TEXT NOT NULL,
    "description" TEXT NOT NULL,
    "status" TEXT NOT NULL,
    "create_at" TEXT NOT NULL,
    "category_id" TEXT NOT NULL,
    PRIMARY KEY("id"),
    FOREIGN KEY("category_id") REFERENCES "categories"("id")
);
