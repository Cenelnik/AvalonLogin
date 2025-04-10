CREATE TABLE IF NOT EXISTS public."Users"
(
    "Guid" uuid NOT NULL,
    "UserName" text COLLATE pg_catalog."default",
    "UserPass" text COLLATE pg_catalog."default",
    "Mail" text COLLATE pg_catalog."default",
    "IsDeleted" boolean,
    "Salt" integer,
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 )
)