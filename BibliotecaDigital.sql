-- Crear la base de datos
CREATE DATABASE BibliotecaDigital;

-- Usar la base de datos
USE BibliotecaDigital;

-- Crear tabla de Libros
CREATE TABLE Libros (
    idLibro INT PRIMARY KEY IDENTITY(1,1),
    titulo VARCHAR(255) NOT NULL,
    autor VARCHAR(255) NOT NULL,
    genero VARCHAR(100) NOT NULL,
    sinopsis TEXT NOT NULL,
    portada_url VARCHAR(500) NOT NULL
);

-- Crear tabla de Calificaciones
CREATE TABLE Calificaciones (
    idCalificacion INT PRIMARY KEY IDENTITY(1,1),
    idLibro INT NOT NULL,
    puntuacion INT CHECK (puntuacion BETWEEN 1 AND 5),
    fechaHora DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (idLibro) REFERENCES Libros(idLibro) ON DELETE CASCADE
);


-- Insertar datos de ejemplo en la tabla Libros
INSERT INTO Libros (titulo, autor, genero, sinopsis, portada_url) VALUES
('Cien años de soledad', 'Gabriel García Márquez', 'Realismo mágico', 'Una saga familiar en Macondo...', 'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1449698815i/28162111.jpg'),
('1984', 'George Orwell', 'Distopía', 'Control totalitario y la resistencia de un individuo...', 'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1657781256i/61439040.jpg'),
('El principito', 'Antoine de Saint-Exupéry', 'Fábula', 'Un viaje filosófico a través de los ojos de un niño...', 'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1328876389i/866618.jpg'),
('Harry Potter y la piedra filosofal', 'J.K. Rowling', 'Fantasía', 'Las aventuras de un joven mago en Hogwarts...', 'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1598823299i/42844155.jpg'),
('Crimen y castigo', 'Fiódor Dostoievski', 'Novela psicológica', 'El dilema moral de un joven intelectual...', 'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1171499594i/103582.jpg'),
('Angeles y Demonios', 'Dan Brown', 'Thriller Policiaco', 'Robert Langdon, el renombrado profesor de simbología de la universidad de Harvard es convocado a un laboratorio de alta seguridad en Suiza...', 'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1303659203i/818018.jpg'),
('Los juegos del hambre', 'Suzanne Collins', 'Distopico', 'Un pasado de guerras ha dejado los 12 distritos que dividen Panem bajo el poder tiránico del Capitolio...', 'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1335891621i/6596839.jpg'),
('Memorias de una Geisha', 'Arthur Golden', 'Ficcion Romance', 'En Memorias de una geisha entramos a un mundo donde las apariencias son de suma importancia...', 'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1388347191i/191224.jpg'),
('Estudio en escarlata', 'Arthur Conan Doyle', 'Novela Policial', 'He aquí el nacimiento del prototipo del detective, modelo de razonamiento deductivo: Sherlock Holmes...', 'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1487650923i/34359047.jpg'),
('Juego de tronos', 'George R.R. Martin', 'Fantasia Epica', 'Tras el largo verano, el invierno se acerca a los Siete Reinos...', 'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1337345848i/1453612.jpg'),
('La comunidad del anillo', 'J.R.R. Tolkien', 'Fantasia Epica', 'En la adormecida e idílica Comarca, un joven hobbit recibe un encargo: custodiar el Anillo Único y emprender el viaje para su destrucción en la Grieta del Destino...', 'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1704737084i/222947.jpg'),
('Dracula', 'Bram Stoker', 'Terror Gotico', 'Jonathan Harker viaja a Transilvania para cerrar un negocio inmobiliario con un misterioso conde que acaba de comprar varias propiedades en Londres...', 'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1389486854i/20514760.jpg'),
('Ciudades de papel', 'John Green', 'Literatura Juvenil', 'Quentin está en su último año de instituto, a punto de graduarse, y tiene un vínculo especial con su vecina Margo, de la que siempre ha estado enamorado...', 'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1401075651i/21495416.jpg'),
('El guerrero a la sombra del cerezo', 'David B. Gil', 'Ficcion Historica', 'Japón, finales del siglo XVI. El país deja atrás la Era de los Estados en Guerra y se adentra en un titubeante periodo de paz....', 'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1506501546i/34216084.jpg')

select * from Libros

select * from Calificaciones
select Calificaciones.idCalificacion, Calificaciones.puntuacion, Calificaciones.fechaHora, Calificaciones.idLibro, Libros.titulo from Calificaciones INNER JOIN Libros on Calificaciones.idLibro = Libros.idLibro