   M S B A M L   `   `   `  ����N  JCncServerController, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CncServerControllerCncServerController  5   	        CncServerController.Client   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:CncServerController     5   	   -   5          � Title$  Client��5   	   $��491.836��6   $��499.941��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      $��0* �6   .+�5   
   �� -   5        $��Connect��5      $
��Left=�6#   $��82��6>   $��16,8,0,0q�6J   $	��Top=�6\   $��82��6t   6   �� 5   
   -   5        $��
Disconnect��5      $
��Left=�6&   $��82��6A   $��	105,8,0,0q�6M   $	��Top=�6`   $��82��6x   6�   �� 5   
   -   5        $��Reset��5      $
��Left=�6!   $��82��6<   $��	194,8,0,0q�6H   $	��Top=�6[   $��81��6s   6~   �� 5   
   -   5        $��ZeroAll��5      $
��Left=�6#   $��81��6>   $��
15,105,0,0q�6J   $	��Top=�6^   $��81��6v   6�   �� 5   
   -   5        $��HomeAll��5      $
��Left=�6#   $��82��6>   $��	283,8,0,0q�6J   $	��Top=�6]   $��81��6u   6�   �� 5   
   -   5        $
��Move��5      $
��Left=�6    $��82��6;   $��
15,193,0,0q�6G   $	��Top=�6[   $��81��6s   6~   �� 5   
   -   5         ��Name$ richtextbox1��5      $
��Left=�6,   $	��352��6G   $��
105,99,0,0q�6T   $	��Top=�6h   $	��259��6�   . �5      /� 5      5      �� 5   
   -	   5         ��Name$ 
LabelXwork��5      $��X : 000.000��6$   $
��Left=�6:   $��38��6U   $��
369,10,0,0q�6a   $	��Top=�6u   $	��106��6�   
���  ��
�������$��20(�6�   �� 5   
   -
   5        $ 
LabelYwork��5      $��Y : 000.000��6$   $
��Left=�6:   $��38��6U   $��
369,53,0,0q�6a   $	��Top=�6u   $	��106��6�   ���	#FF0CFF00
�������$��20(�6�   �� 5   
   -   5        $ 
LabelZwork��5      $��Z : 000.000��6$   $
��Left=�6:   $��38��6U   $��
369,96,0,0q�6a   $	��Top=�6u   $	��106��6�   ���	#FF0023FF
�������$��20(�6�   �� 5   
   -   5        $ 
LabelXmach��5      $��X : 000.000��6$   $
��Left=�6:   $��38��6U   $��369,142,0,0q�6a   $	��Top=�6v   $	��106��6�   ���	#FF147E36
�������$��20(�6�   �� 5   
   -   5        $ 
LabelYmach��5      $��Y : 000.000��6$   $
��Left=�6:   $��38��6U   $��369,185,0,0q�6a   $	��Top=�6v   $	��106��6�   ���	#FF147E36
�������$��20(�6�   �� 5   
   -   5        $ 
LabelZmach��5      $��Z : 000.000��6$   $
��Left=�6:   $��38��6U   $��369,228,0,0q�6a   $	��Top=�6v   $	��106��6�   ���	#FF147E36
�������$��20(�6�   5       5!      