package com.example.DatabaseProject;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/Book")
public class BookController {

	@Autowired
	private BookRepository bookRepository;
	
	@PostMapping("/add")
	public void addBook(@RequestBody Book book) 
	{
		this.bookRepository.save(book);
	}
	
	@DeleteMapping("/del/{id}")
	public void deleteBook(@PathVariable Integer id) {
		this.bookRepository.deleteById(id);		
	}
	
	@GetMapping("/getAll")
	public List<Book> getAllBooks()
	{
		
		if(bookRepository.count()!=0)
			return bookRepository.findAll();
    	return null;
	}
	
	@GetMapping("/get/{id}")
	public Book getBook(@PathVariable Integer id) 
	{
	    if(bookRepository.existsById(id))
	    	return bookRepository.findById(id).get();
	    return null;
	}
	 
	@PutMapping("/update/{id}")
	public void updateBook(@PathVariable Integer id,@RequestBody Book book) 
	{
		if(bookRepository.existsById(id)) 
		{
			Book existingBook = bookRepository.findById(id).get();
			existingBook.setPublisher_id(book.getPublisher_id());
			existingBook.setAuthor_id(book.getAuthor_id());
			existingBook.setPage_number(book.getPage_number());
			existingBook.setBook_title(book.getBook_title());
			existingBook.setStatus(book.getStatus());
			existingBook.setType(book.getType());
			bookRepository.save(existingBook);
			return;
		}
	}	
}
