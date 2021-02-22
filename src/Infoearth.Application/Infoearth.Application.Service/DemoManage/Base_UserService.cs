using Infoearth.Application.Entity.DemoManage;
using Infoearth.Application.IService.DemoManage;
using Infoearth.Data.Repository;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using Infoearth.Util.Extension;
using System.Collections.Generic;
using System.Linq;

namespace Infoearth.Application.Service.DemoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ���̹ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-01-09 16:18
    /// �� �����û���Ϣ��
    /// </summary>
    public class Base_UserService : RepositoryFactory<Base_UserEntity>, Base_UserIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<Base_UserEntity> GetPageList(Pagination pagination, string queryJson)
        {
               var expression = LinqExtensions.True<Base_UserEntity>();
             return this.BaseRepository("LeaRunFramework_Base_2016","SqlServer").FindList(expression,pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<Base_UserEntity> GetList(string queryJson)
        {
            return this.BaseRepository("LeaRunFramework_Base_2016","SqlServer").IQueryable().ToList();
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public Base_UserEntity GetEntity(string keyValue)
        {
            return this.BaseRepository("LeaRunFramework_Base_2016","SqlServer").FindEntity(keyValue);
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string keyValue)
        {
            this.BaseRepository("LeaRunFramework_Base_2016","SqlServer").Delete(keyValue);
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, Base_UserEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.BaseRepository("LeaRunFramework_Base_2016","SqlServer").Update(entity);
            }
            else
            {
                entity.Create();
               this.BaseRepository("LeaRunFramework_Base_2016","SqlServer").Insert(entity);
            }
        }
        #endregion
    }
}
