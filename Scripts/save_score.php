<?php
// Include WordPress functions if not running in a native WP environment
require_once($_SERVER['DOCUMENT_ROOT'] . '/wk1/wp-load.php');

// For debugging: check if WordPress is loading correctly
if (function_exists('is_user_logged_in')) {
    error_log("WordPress loaded successfully.");
} else {
    error_log("WordPress failed to load.");
}

// Check if user is logged in
if (is_user_logged_in()) {
    $current_user = wp_get_current_user();
    error_log("User ID: " . $current_user->ID);  // Log the current user ID for debugging

    if (isset($_POST['score']) && is_numeric($_POST['score'])) {
        $score = intval($_POST['score']);
        update_user_meta($current_user->ID, 'game_1_score', $score);
        echo json_encode(['status' => 'success', 'message' => 'Score updated successfully.']);
    } else {
        echo json_encode(['status' => 'error', 'message' => 'Invalid score input.']);
    }
} else {
    error_log("User not logged in.");
    echo json_encode(['status' => 'error', 'message' => 'User not logged in.']);
}

?>