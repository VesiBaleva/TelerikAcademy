<?php
/**
 * Template Name: Blog Template
 */
get_header();
?>
		<h2>My Blog Page</h2>
		<?php
		$blog_query=new WP_Query('author=1');
		if($blog_query->have_posts()):
		while ($blog_query->have_posts()):			
				$blog_query->the_post();
	
	?>
	<h1><?php the_title();?></h1>
	<p>
		<?php the_content();?>
	</p>
	<?php 
	endwhile;
		endif;
		wp_reset_query();
	?>


<?php get_footer();?>