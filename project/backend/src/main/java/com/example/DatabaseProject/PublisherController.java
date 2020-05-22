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
@RequestMapping("/Publisher")
public class PublisherController {
	
	@Autowired
	private PublisherRepository publisherRepository;
	
    @PostMapping("/add")
	public void addPublisher(@RequestBody Publisher publisher) 
	{
		this.publisherRepository.save(publisher);
	}
    
    @DeleteMapping("/del/{id}")
	public void deletePublisher(@PathVariable Integer id) {
		this.publisherRepository.deleteById(id);		
	}
    
    @GetMapping("/getAll")
	public List<Publisher> getAllPublishers()
	{
		
		if(publisherRepository.count()!=0)
			return publisherRepository.findAll();
    	return null;
	}
    
    @GetMapping("/get/{id}")
	public Publisher getPublisher(@PathVariable Integer id) 
	{
    	if(publisherRepository.existsById(id))
    		return publisherRepository.findById(id).get();
    	return null;
	}
    
    
    @PutMapping("/update/{id}")
	public void updatePublisher(@PathVariable Integer id,@RequestBody Publisher publisher) 
	{
		if(publisherRepository.existsById(id)) 
		{
			Publisher existingPublisher = publisherRepository.findById(id).get();
			existingPublisher.setName(publisher.getName());
			publisherRepository.save(existingPublisher);
		}
	}
}
