% Initialization 
clear; close all; clc






% Set path
addpath('C:\Users\barse\Desktop\OngoingSoftwareProjects\DigitRecognizer');

% Parameters
input_layer_size = 400;
hidden_layer_size = 25;
num_labels = 10;


% Loading training data
fprintf('Loading Training Data...\n')
load('ex4data1.mat');
fprintf('Data loaded!\n')


m = size(X, 1);


load('ex4weights.mat');

% Unroll params
nn_params = [Theta1(:) ; Theta2(:)];

lambda = 1;

J = nnCostFunction(nn_params, input_layer_size, hidden_layer_size, ...
                   num_labels, X, y, lambda);

				   
% Random initialization of weigths
initial_Theta1 = randInitializeWeights(input_layer_size, hidden_layer_size);
initial_Theta2 = randInitializeWeights(hidden_layer_size, num_labels);


% Unroll parameters
initial_nn_params = [initial_Theta1(:) ; initial_Theta2(:)];


% Create shorthand for cost function
costFunction = @(p) nnCostFunction(p, ...
                                   input_layer_size, ...
                                   hidden_layer_size, ...
                                   num_labels, X, y, lambda);
								   

% Minimize cost function	
fprintf('Traning neural network...\n')
options = optimset('MaxIter', 50);							   
[nn_params, cost] = fmincg(costFunction, initial_nn_params, options);



% obtain Theta1 and Theta2 from the nn params
Theta1 = reshape(nn_params(1:hidden_layer_size * (input_layer_size + 1)), ...
                 hidden_layer_size, (input_layer_size + 1));

Theta2 = reshape(nn_params((1 + (hidden_layer_size * (input_layer_size + 1))):end), ...
                 num_labels, (hidden_layer_size + 1));




			 
% load image

fprintf('Loading image..\n')
I = imread('C:\Users\barse\Desktop\OngoingSoftwareProjects\DigitRecognizer\scaledImage.jpg');
fprintf('Image loaded!\n');


imshow(I);



pred = predict(Theta1, Theta2, X);
fprintf('\nTraining Set Accuracy: %f\n', mean(double(pred == y)) * 100);
