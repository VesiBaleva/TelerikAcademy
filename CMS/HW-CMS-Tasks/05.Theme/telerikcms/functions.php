<?php
$sidebar_args=array(
		'id' => 'right-sidebar',
		'name' => 'Main Sidebar',
		'before_widget' => '<div class="sidebar"> <ul>',
		'after_widget'  => '</ul> </div>',
		'before_title'  => '<h3>',
		'after_title'   => '</h3>' 
		);
register_sidebar($sidebar_args);

register_nav_menu('top-site-menu', 'This is my top site menu');