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
@RequestMapping("/Author")
public class AuthorController {
	
	@Autowired
	private AuthorRepository authorRepository;
	
    @PostMapping("/add") 
	public void addAuthor(@RequestBody Author author) 
	{
		this.authorRepository.save(author);
	}
    
    @DeleteMapping("/del/{id}") 
	public void deleteAuthor(@PathVariable Integer id) {
		this.authorRepository.deleteById(id);		
	}
    
    @GetMapping("/getAll")
	public List<Author> getAllAuthors()
	{
		
    	if(authorRepository.count()!=0)
			return authorRepository.findAll();
    	return null;
	}
    
    @GetMapping("/get/{id}")
	public Author getAuthor(@PathVariable Integer id) 
	{
    	if(authorRepository.existsById(id))
    		return authorRepository.findById(id).get();
    	return null;
	}
    
    
    @PutMapping("/update/{id}")
	public void updateAuthor(@PathVariable Integer id,@RequestBody Author author) 
	{
		if(authorRepository.existsById(id)) 
		{
			Author existingAuthor = authorRepository.findById(id).get();
			existingAuthor.setName(author.getName());
			existingAuthor.setSurname(author.getSurname());
			authorRepository.save(existingAuthor);
			return;
			
		}
		System.out.println("The author does not exits so cannot be updated.");
	}
	
}
