// ***********************************************************************************
//  Created by zbw911 
//  �����ڣ�2013��06��03�� 16:48
//  
//  �޸��ڣ�2013��06��03�� 17:25
//  �ļ�����CASServer/Domain.Entities/sysdiagram.cs
//  
//  ����и��õĽ����������ʼ��� zbw911#gmail.com
// ***********************************************************************************

using System;

namespace Domain.Entities.Models
{
    public partial class sysdiagram
    {
        #region Instance Properties

        public byte[] definition { get; set; }
        public int diagram_id { get; set; }
        public string name { get; set; }
        public int principal_id { get; set; }
        public Nullable<int> version { get; set; }

        #endregion
    }
}