CREATE TABLE login.role
(
    role_id bigint NOT NULL DEFAULT nextval('login.role_role_id_seq'::regclass),
    name text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT role_pkey PRIMARY KEY (role_id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE login.role
    OWNER to postgres;


CREATE TABLE login."user"
(
    user_id bigint NOT NULL DEFAULT nextval('login.user_user_id_seq'::regclass),
    role_id bigint NOT NULL,
    username text COLLATE pg_catalog."default" NOT NULL,
    password bytea NOT NULL,
    salt bytea NOT NULL,
    CONSTRAINT user_pkey PRIMARY KEY (user_id),
    CONSTRAINT user_role_fk FOREIGN KEY (role_id)
        REFERENCES login.role (role_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE login."user"
    OWNER to postgres;


INSERT INTO login."role" (name)
VALUES ('Admin');