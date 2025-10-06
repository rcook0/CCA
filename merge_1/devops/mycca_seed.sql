-- mycca_seed.sql
-- Seed initial roles and test users for MyCCA

-- Roles table
CREATE TABLE IF NOT EXISTS roles (
    id SERIAL PRIMARY KEY,
    name VARCHAR(50) UNIQUE NOT NULL
);

INSERT INTO roles (name) VALUES
    ('admin'),
    ('counselor'),
    ('student')
ON CONFLICT DO NOTHING;

-- Users table (simplified for demo)
CREATE TABLE IF NOT EXISTS users (
    id UUID PRIMARY KEY,
    email VARCHAR(255) UNIQUE NOT NULL,
    role_id INT REFERENCES roles(id),
    first_name VARCHAR(100),
    last_name VARCHAR(100),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Example users
INSERT INTO users (id, email, role_id, first_name, last_name)
VALUES
    (gen_random_uuid(), 'admin@example.com', (SELECT id FROM roles WHERE name='admin'), 'Alice', 'Admin'),
    (gen_random_uuid(), 'counselor@example.com', (SELECT id FROM roles WHERE name='counselor'), 'Bob', 'Counselor'),
    (gen_random_uuid(), 'student@example.com', (SELECT id FROM roles WHERE name='student'), 'Charlie', 'Student')
ON CONFLICT DO NOTHING;
